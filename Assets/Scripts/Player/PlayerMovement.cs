using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float jumpForce = 5f;


    public float maxXPos = 3;
    public float minXPos = -3;

    public BoxCollider headCollider;
    public RotateWorld worldRotation;

    public bool isJumping = false;
    private bool isRolling = false;
    private bool isStopped = false;

    private Rigidbody rb;
    private float minHeight;
    public int obstaclesColiding;



    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = normalSpeed;
        minHeight = transform.position.y - 0.2f;
        obstaclesColiding = 0;
    }

    public void Update()
    {
        Move();
        Jump();
        Roll();
    }

    public IEnumerator GoBackToNormalSpeed()
    {
        yield return new WaitForSeconds(1f);
        playerSpeed = normalSpeed;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Tierra"))
        {
            isJumping = false;
        }

        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            worldRotation.speedRot = worldRotation.tripSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {
            worldRotation.speedRot = worldRotation.tripSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            obstaclesColiding++;
            isStopped = true;
            worldRotation.speedRot = worldRotation.stopSpeed;
            playerSpeed = slowSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            isStopped = true;
            worldRotation.speedRot = worldRotation.stopSpeed;
            playerSpeed = slowSpeed;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            obstaclesColiding--;
            if (obstaclesColiding == 0)
            {
                isStopped = false;
                worldRotation.speedRot = worldRotation.normalSpeed;
                playerSpeed = normalSpeed;
            }
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            playerSpeed = normalSpeed;
        }
    }

    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isRolling && !isJumping && !isStopped)
            {
                worldRotation.speedRot = worldRotation.rollSpeed;
                headCollider.enabled = true;
                StartCoroutine("GoBackToNormalSpeed");
                isRolling = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isRolling = false;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if (!isRolling && !isJumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
                isJumping = true;
            }
        }
    }


    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, 0);

        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);
        transform.position = transform.position + movementDirection * playerSpeed * Time.deltaTime;

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
}
