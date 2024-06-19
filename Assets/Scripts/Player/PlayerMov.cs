using System.Collections;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float jumpForce = 5f;
    public float maxXPos = 3;
    public float minXPos = -3;
    public float scaleWhenRolling;
    public float positionWhenRolling;
    
    public Animator animator;
    public RotateWorld worldRotation;
    public GameObject body;

    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isOnPlatform = false;
    [HideInInspector] public bool somethingLeft = false;
    [HideInInspector] public bool somethingRight = false;
    [HideInInspector] public float playerSpeed;

    private bool isRolling = false;
    private Rigidbody rb;
    private float minHeight;
    private float originalScale;
    private float originalBodyHeight;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = normalSpeed;
        minHeight = transform.position.y - 0.2f;
        originalScale = body.transform.localScale.y;
        originalBodyHeight = body.transform.localPosition.y;
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
                animator.SetBool("SeAgacha", true);
                Vector3 scaleBody = body.transform.localScale;
                scaleBody.y = scaleWhenRolling;
                body.transform.localScale = scaleBody;

                Vector3 posBody = body.transform.localPosition;
                posBody.y += positionWhenRolling;
                body.transform.localPosition = posBody;

                worldRotation.speedRot = worldRotation.rollSpeed;
                Invoke("GoBackToNormalSpeed", 0.5f);
                isRolling = true;
            }
        }
    }

    public void GoBackToNormalSpeed()
    {
        animator.SetBool("SeAgacha", false);
        if (worldRotation.speedRot == worldRotation.rollSpeed)
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
        }
        Vector3 scaleBody = body.transform.localScale;
        scaleBody.y = originalScale;
        body.transform.localScale = scaleBody;

        Vector3 posBody = body.transform.localPosition;
        posBody.y = originalBodyHeight;
        body.transform.localPosition = posBody;
        isRolling = false;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if (!isRolling && !isJumping)
            {
                animator.Play("Jump");
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

            if( rb.velocity.y < 0 )
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
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
