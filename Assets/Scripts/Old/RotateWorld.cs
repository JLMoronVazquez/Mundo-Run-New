using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float normalSpeed, rollSpeed, tripSpeed, carSpeed, boatSpeed, stopSpeed;
    public Transform playerTr, playerHeadTr;
    public LayerMask layerObstacles;
    public LayerMask layerBrake;
    public LayerMask layerJump;

    [HideInInspector] public float speedRot;
    private Rigidbody rb;
    private bool rolling;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speedRot = normalSpeed;
    }

    public void Update()
    {
        Roll();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);
        //speedRot = normalSpeed;
        if (dirtUnderPlayer())
        {
            speedRot = tripSpeed;
            Invoke("StopTrip", 0.9f);
        }

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);
        if (!ObstacleAheadPlayer())
        {
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }



    private bool ObstacleAheadPlayer()
    {
        bool obstacleAhead = false;

        RaycastHit hit;
        Vector3 posOrogin = playerTr.position + Vector3.up * 0.25f;
        Debug.DrawRay(posOrogin, playerTr.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(posOrogin, playerTr.TransformDirection(Vector3.forward), out hit, 0.4f, layerObstacles))
        {
            //print(hit.collider.gameObject.name);
            obstacleAhead = true;
        }

        if (!rolling)
        {
            if (Physics.Raycast(playerHeadTr.position, playerHeadTr.TransformDirection(Vector3.forward), out hit, 0.4f, layerObstacles))
            {
                //print(hit.collider.gameObject.name);
                obstacleAhead = true;
            }
        }

        return obstacleAhead;
    }

    private bool dirtUnderPlayer()
    {
        RaycastHit hit;
        Vector3 posOrogin = playerTr.position + Vector3.up * 0.25f;
        Debug.DrawRay(posOrogin, playerTr.TransformDirection(Vector3.down), Color.blue);
        if (Physics.Raycast(posOrogin, playerTr.TransformDirection(Vector3.down), out hit, 0.4f, layerBrake))
        {
            //print(hit.collider.gameObject.name);
            return true;
        }
        return false;
    }


    private void Roll()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if ( !dirtUnderPlayer() && PlayerIsGrounded())
            {
                rolling = true;
                speedRot = rollSpeed;
                Invoke("StopRoll", 0.4f);
            }
        }
    }

    private void StopRoll()
    {
        speedRot = normalSpeed;
        rolling = false;
    }

    private void StopTrip()
    {
        speedRot = normalSpeed;
    }


    private bool PlayerIsGrounded()
    {
        RaycastHit hit;
        Vector3 posOrogin = playerTr.position + Vector3.up * 0.25f;
        Debug.DrawRay(posOrogin, playerTr.TransformDirection(Vector3.down * 0.5f), Color.yellow);
        if (Physics.Raycast(posOrogin, playerTr.TransformDirection(Vector3.down), out hit, 0.5f, layerJump))
        {
            return true;
        }
        return false;
    }
}
