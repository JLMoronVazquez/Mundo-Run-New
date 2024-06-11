using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public bool isJumping = false;

    public float MaxXPos = 3;
    public float MinXPos = -3;

    public BoxCollider headCollider;

    private bool isRolling = false;
    private Rigidbody rb;
    //private Animator animator;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
        //animator.SetBool("SeAgacha", false);
        
    }

    private void Update()
    {
        Move();


        if (transform.position.x > MaxXPos)
        {
            transform.position = new Vector3(MaxXPos, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < MinXPos)
        {
            transform.position = new Vector3(MinXPos, transform.position.y, transform.position.z);
        }


        //animator.SetBool("Teclas", true);

        Jump();
        Roll();
    }

    IEnumerator SeAgachaColision()
    {
        yield return new WaitForSeconds(1f);
        //animator.SetBool("SeAgacha", false);
        //animator.SetBool("Parado", false);
        speed = 5f;
    }


    private void OnCollisionEnter(Collision collision)
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

            Stand();

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

        if (collision.collider.CompareTag("Untagged"))
        {
            //animator.SetBool("Parado", false);
            //animator.SetBool("Teclas", false);
            //animator.SetBool("AndarLado", false);

            speed = 5f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            //animator.SetBool("Tropieza", true);
        }

        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {

        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            StartCoroutine("TiempoTropiezo");
            //animator.SetBool("Tropieza", false);
            rb.mass = 10;

        }
        if (other.GetComponent<Collider>().CompareTag("Frenar"))
        {
        }
    }
    IEnumerator TiempoTropiezo()
    {
        yield return new WaitForSeconds(1f);
        rb.mass = 1;

    }

    public void GoLeft()
    {
        //animator.Play("AndarIzquierda");
        //animator.SetBool("AndarLado", true);
        //animator.SetBool("Teclas", false);
        speed = 2f;
        return;
    }

    public void GoRight()
    {
        //animator.Play("AndarDerecha");
        //animator.SetBool("AndarLado", true);
        //animator.SetBool("Teclas", false);
        speed = 2f;
        return;
    }

    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isRolling && !isJumping)
            {
                //animator.Play("Agacharse");
                //animator.SetBool("SeAgacha", true);
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
                rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                isJumping = true;
            }
        }
    }


    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);

        if (movementDirection.x > MaxXPos)
        {
            movementDirection.x = MaxXPos;
        }

        if (movementDirection.x < MinXPos)
        {
            movementDirection.x = MinXPos;
        }

        rb.MovePosition(transform.position + movementDirection * speed * Time.deltaTime);
    }

    public void Stand()
    {

    }
}
