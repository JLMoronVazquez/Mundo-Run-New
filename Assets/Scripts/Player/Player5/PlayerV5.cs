using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerV5 : MonoBehaviour
{
    public float speed, rollSpeed, normalSpeed, tripSpeed;
    public float rollDuration, tripDuration;
    public float jumpForce, customGravity;
    public float rotationSpeed;
    public Transform head, model;

    public LayerMask layerJump, layerTrip, layerObstacles;

    private Rigidbody rb;
    private bool isRolling, isTripping;
    private float timerRoll, timerTrip;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isRolling = false;
        isTripping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Roll();
        Trip(); 
    }

    public void Move()
    {
        Vector2 inputMov = new Vector2();
        inputMov.x = Input.GetAxisRaw("Horizontal");
        inputMov.y = Input.GetAxisRaw("Vertical");
        Orientate(inputMov);
        
        inputMov = inputMov.normalized * speed;

        if( !CheckAhead(inputMov) )
        {
            rb.velocity = new Vector3(inputMov.x, rb.velocity.y, inputMov.y);
        }
        
    }

    private void Orientate( Vector2 direction )
    {
        if( direction.magnitude > 0.5f )
        {
            head.localPosition = new Vector3(direction.x, 0, direction.y);
            model.transform.DOLookAt(head.position, rotationSpeed);
        }
    }

    private void Jump()
    {
        if( !CheckGround() )
        {
            rb.AddForce(Vector3.down * customGravity * 30 * Time.deltaTime );
        }

        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            if (!isRolling)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            }
        }
    }

    private bool CheckGround()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, Vector3.down, 0.5f, layerJump);
    }

    private bool CheckTrip()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, Vector3.down, 0.5f, layerTrip);
    }

    private void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckGround() && !isRolling && !isTripping)
        {
            isRolling = true;
            speed = rollSpeed;
            timerRoll = rollDuration;
        }

        if( isRolling )
        {
            timerRoll -= Time.deltaTime;
            if( timerRoll < 0 )
            {
                speed = normalSpeed;
                timerRoll = rollDuration;
                isRolling = false;
            }
        }
    }

    private void Trip()
    {
        if (CheckTrip())
        {
            isTripping = true;
            speed = tripSpeed;
            timerTrip = tripDuration;
        }

        if( isTripping )
        {
            timerRoll -= Time.deltaTime;
            if( timerTrip < 0 )
            {
                speed = normalSpeed;
                timerTrip = tripDuration;
                isTripping = false;
            }
        }
    }

    private bool CheckAhead( Vector2 direction )
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, direction, 0.5f, layerObstacles);
    }
}
