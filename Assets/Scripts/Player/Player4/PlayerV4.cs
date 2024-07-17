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
    private Rigidbody rb;
    private bool isRolling = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = normalSpeed;
    }

    public void Update()
    {
        MoveX();
        MoveZ();
        Jump();
    }

    private void MoveZ()
    {
        if ( Input.GetKey(KeyCode.W) && !CheckAhead() )
        {
            Vector3 playerPos = transform.position;
            playerPos.z += playerSpeed * Time.deltaTime;
            transform.position = playerPos;
        }

        if ( Input.GetKey(KeyCode.S) && !CheckBack() )
        {
            Vector3 playerPos = transform.position;
            playerPos.z -= playerSpeed * Time.deltaTime;
            transform.position = playerPos;
        }
    }

    private void MoveX()
    {
        //Vector3 forceToPlayer = new Vector3();
        if ( Input.GetKey(KeyCode.A) && transform.position.x > minXPos && !CheckLeft() )
        {
            Vector3 playerPos = transform.position;
            playerPos.x -= playerSpeed * Time.deltaTime;
            transform.position = playerPos;
        }

        if ( Input.GetKey(KeyCode.D) && transform.position.x < maxXPos && !CheckRight() )
        {
            Vector3 playerPos = transform.position;
            playerPos.x += playerSpeed * Time.deltaTime;
            transform.position = playerPos;
        }
    }

    private void Jump()
    {
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

    private bool CheckLeft()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        Debug.DrawRay(origin, Vector3.left, Color.red);
        return Physics.Raycast(origin, Vector3.left, 0.5f, layerObstacles);
    }

    private bool CheckRight()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, Vector3.right, 0.5f, layerObstacles);
    }

    private bool CheckAhead()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, Vector3.forward, 0.5f, layerObstacles);
    }

    private bool CheckBack()
    {
        Vector3 origin = transform.position + Vector3.up * 0.15f;
        return Physics.Raycast(origin, Vector3.back, 0.5f, layerObstacles);
    }


}
