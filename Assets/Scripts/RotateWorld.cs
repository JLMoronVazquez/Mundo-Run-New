using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float normalSpeed, rollSpeed, tripSpeed, carSpeed, boatSpeed, stopSpeed;
    public Transform player;
    public LayerMask layerObstacles;
    public LayerMask layerBrake;

    [HideInInspector] public float speedRot;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speedRot = normalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);
        speedRot = normalSpeed;
        if(dirtUnderPlayer())
        {
            speedRot = tripSpeed;
        }

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);
        if (!ObstacleAheadPlayer())
        {
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }



    private bool ObstacleAheadPlayer()
    {
        RaycastHit hit;
        Vector3 posOrogin = transform.position + Vector3.up*0.25f;
        Debug.DrawRay(posOrogin, transform.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(posOrogin, transform.TransformDirection(Vector3.forward), out hit, 0.4f, layerObstacles))
        {
            //print(hit.collider.gameObject.name);
            return true;
        }
        return false;
    }

    private bool dirtUnderPlayer()
    {
        RaycastHit hit;
        Vector3 posOrogin = transform.position + Vector3.up*0.25f;
        Debug.DrawRay(posOrogin, transform.TransformDirection(Vector3.down), Color.blue);
        if (Physics.Raycast(posOrogin, transform.TransformDirection(Vector3.down), out hit, 0.4f, layerBrake))
        {
            //print(hit.collider.gameObject.name);
            return true;
        }
        return false;
    }
}
