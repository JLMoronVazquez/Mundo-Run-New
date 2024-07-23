using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerV5 : MonoBehaviour
{
    public float speed, rollSpeed, normalSpeed, tripSpeed;
    public float rollDuration, rollCooldownDuration, tripDuration, jumpDuration;
    public float jumpForce, customGravity;
    public float rotationSpeed;
    public Transform head, model;

    public LayerMask layerJump, layerTrip, layerObstacles;

    private Rigidbody rb;
    private bool isRolling, isTripping, isRollInCooldown, isJumping;
    private float timerRoll, timerTrip, timerJump, timerRollCooldown;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isRolling = false;
        isTripping = false;
        isRollInCooldown = false;
        isJumping = false;
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

        if (!CheckAhead(inputMov))
        {
            rb.velocity = new Vector3(inputMov.x, rb.velocity.y, inputMov.y);
        }

    }

    private void Orientate(Vector2 direction)
    {
        if (direction.magnitude > 0.5f)
        {
            head.localPosition = new Vector3(direction.x, 0, direction.y);
            model.transform.DOLookAt(head.position, rotationSpeed);
        }
    }

    private void Jump()
    {
        if (!CheckGround())
        {
            rb.AddForce(Vector3.down * customGravity * 30 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            if (!isRolling)
            {
                isJumping = true;
                timerJump = jumpDuration;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (timerJump > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                timerJump -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckGround() && !isRollInCooldown && !isTripping)
        {
            isRollInCooldown = true;
            isRolling = true;
            speed = rollSpeed;
            timerRoll = rollDuration;
            timerRollCooldown = rollCooldownDuration;
        }

        if (isRolling)
        {
            timerRoll -= Time.deltaTime;
            if (timerRoll < 0)
            {
                speed = normalSpeed;
                isRolling = false;
            }
        }

        if (isRollInCooldown)
        {
            timerRollCooldown -= Time.deltaTime;
            if (timerRollCooldown < 0)
            {
                isRollInCooldown = false;
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

        if (isTripping)
        {
            timerRoll -= Time.deltaTime;
            if (timerTrip < 0)
            {
                speed = normalSpeed;
                timerTrip = tripDuration;
                isTripping = false;
            }
        }
    }

    private bool CheckAhead(Vector2 direction2)
    {
        Vector3 direction = new Vector3( direction2.x, 0, direction2.y );
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, direction, 0.5f, layerObstacles);
    }
}
