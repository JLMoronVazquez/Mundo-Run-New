using System.Collections;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float jumpForce = 5f;

    public float maxXPos = 3;
    public float minXPos = -3;

    public RotateWorld worldRotation;

    public float scaleWhenRolling;

    public GameObject body;

    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isOnPlatform = false;
    [HideInInspector] public bool somethingLeft = false;
    [HideInInspector] public bool somethingRight = false;
    private bool isRolling = false;

    [HideInInspector] public float playerSpeed;
    private Rigidbody rb;
    private float minHeight;

    private float originalScale;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = normalSpeed;
        minHeight = transform.position.y - 0.2f;
        originalScale = body.transform.localScale.y;
    }

    public void Update()
    {
        Move();
        Jump();
        Roll();
    }



    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isRolling && !isJumping && worldRotation.speedRot != worldRotation.stopSpeed)
            {
                Vector3 scaleBody = body.transform.localScale;
                scaleBody.y = scaleWhenRolling;
                body.transform.localScale = scaleBody;
                worldRotation.speedRot = worldRotation.rollSpeed;
                Invoke("GoBackToNormalSpeed", 0.5f);
                isRolling = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isRolling = false;
        }
    }

    public void GoBackToNormalSpeed()
    {
        if (worldRotation.speedRot == worldRotation.rollSpeed)
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
        }
        Vector3 scaleBody = body.transform.localScale;
        scaleBody.y = originalScale;
        body.transform.localScale = scaleBody;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if (!isRolling && !isJumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
                isOnPlatform = false;
                isJumping = true;
            }
        }
    }


    public void Move()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        Vector3 movementDirection = GetHorzontalInput();

        transform.position = transform.position + movementDirection * playerSpeed * Time.deltaTime;

        if (isOnPlatform)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }

        if (transform.position.x > maxXPos)
        {
            Vector3 posPlayer = transform.position;
            posPlayer.x = maxXPos;
            transform.position = posPlayer;
        }

        if (transform.position.x < minXPos)
        {
            Vector3 posPlayer = transform.position;
            posPlayer.x = minXPos;
            transform.position = posPlayer;
        }

        if (transform.position.y < minHeight)
        {
            Vector3 posPlayer = transform.position;
            posPlayer.y = minHeight;
            transform.position = posPlayer;
        }
    }


    public Vector3 GetHorzontalInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (somethingLeft && horizontalInput < 0)
        {
            horizontalInput = 0;
        }

        if (somethingRight && horizontalInput > 0)
        {
            horizontalInput = 0;
        }

        return new Vector3(horizontalInput, 0, 0);
    }
}
