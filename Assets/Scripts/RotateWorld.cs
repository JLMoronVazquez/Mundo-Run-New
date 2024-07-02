using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float normalSpeed, rollSpeed, tripSpeed, carSpeed, boatSpeed, stopSpeed;
    public Transform player;
    public LayerMask layerObstacles;

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

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);
        if (!ObstacleAheadPlayer())
        {
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }



    private bool ObstacleAheadPlayer()
    {
        RaycastHit hit;
        Vector3 posOrogin = player.transform.position + Vector3.up*0.25f;
        Debug.DrawRay(posOrogin, player.transform.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(posOrogin, player.transform.TransformDirection(Vector3.forward), out hit, 0.4f, layerObstacles))
        {
            //print(hit.collider.gameObject.name);
            return true;
        }
        return false;
    }
}
