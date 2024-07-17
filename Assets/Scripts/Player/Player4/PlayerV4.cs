using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerV4 : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float jumpForce = 5f;
    public float maxXPos = 3;
    public float minXPos = -3;


    public LayerMask layerObstacles, layerBrake, layerJump;

    public GameObject Head;

    private float playerSpeed;
    private bool isGrounded = true;
    private Rigidbody rb;
    private bool isRolling = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = normalSpeed;
    }

    public void Update()
    {
        checkGround();
        MoveX();
        MoveZ();
        Jump();
    }

    private void MoveZ()
    {
        
    }

    private void MoveX()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
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
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (!isRolling)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            }
        }
    }

    private void checkGround()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        isGrounded = Physics.Raycast(origin, Vector3.down, 0.5f, layerJump);
    }
}
