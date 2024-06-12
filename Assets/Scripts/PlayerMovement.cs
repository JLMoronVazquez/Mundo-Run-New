using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float jumpForce = 5f;


    public float MaxXPos = 3;
    public float MinXPos = -3;

    public BoxCollider headCollider;
    public RotateWorld worldRotation;

    private bool isJumping = false;
    private bool isRolling = false;
    private bool isStopped = false;
    public float speed;
    private Rigidbody rb;
    //private Animator animator;



    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = normalSpeed;
        //animator = GetComponent<Animator>();
        //animator.SetBool("SeAgacha", false);
    }

    public void Update()
    {
        Move();
        //animator.SetBool("Teclas", true);
        Jump();
        Roll();
    }

    public IEnumerator SeAgachaColision()
    {
        yield return new WaitForSeconds(1f);
        //animator.SetBool("SeAgacha", false);
        //animator.SetBool("Parado", false);
        speed = normalSpeed;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tierra"))
        {
            isJumping = false;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Untagged"))
        {
            isStopped = true;
            worldRotation.speedRot = worldRotation.stopSpeed;
            if (Input.GetKey(KeyCode.A))
            {
                GoLeft();
                return;
            }

            if (Input.GetKey(KeyCode.D))
            {
                GoRight();
                return;
            }
        }


        if (collision.collider.CompareTag("Agachate"))
        {
            //animator.SetBool("Parado", true);
            //animator.SetBool("AndarLado", false);

            if (Input.GetKey(KeyCode.A))
            {
                GoLeft();
                return;
            }
            if (Input.GetKey(KeyCode.D))
            {
                GoRight();
                return;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        isStopped = false;
        worldRotation.speedRot = worldRotation.normalSpeed;
        if (collision.collider.CompareTag("Untagged"))
        {
            
            worldRotation.speedRot = worldRotation.normalSpeed;
            //animator.SetBool("Parado", false);
            //animator.SetBool("Teclas", false);
            //animator.SetBool("AndarLado", false);

            speed = normalSpeed;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            worldRotation.speedRot = worldRotation.tripSpeed;
            //animator.SetBool("Tropieza", true);
        }

        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {
            worldRotation.speedRot = worldRotation.tripSpeed;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
            //animator.SetBool("Tropieza", false);
        }

        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {
            worldRotation.speedRot = worldRotation.normalSpeed;
        }
    }

    public void GoLeft()
    {
        //animator.Play("AndarIzquierda");
        //animator.SetBool("AndarLado", true);
        //animator.SetBool("Teclas", false);
        speed = slowSpeed;
        return;
    }

    public void GoRight()
    {
        //animator.Play("AndarDerecha");
        //animator.SetBool("AndarLado", true);
        //animator.SetBool("Teclas", false);
        speed = slowSpeed;
        return;
    }

    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isRolling && !isJumping && !isStopped)
            {
                //animator.Play("Agacharse");
                //animator.SetBool("SeAgacha", true);
                worldRotation.speedRot = worldRotation.rollSpeed;
                headCollider.enabled = true;
                StartCoroutine("SeAgachaColision");
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
                //animator.SetBool("Teclas", false);
                //animator.Play("Jump");
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
        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

        if (transform.position.x > MaxXPos)
        {
            Vector3 posPlayer = transform.position;
            posPlayer.x = MaxXPos;
            transform.position = posPlayer;
        }

        if (transform.position.x < MinXPos)
        {
            Vector3 posPlayer = transform.position;
            posPlayer.x = MinXPos;
            transform.position = posPlayer;
        }
    }
}
