using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float normalSpeed, rollSpeed, tripSpeed, carSpeed, boatSpeed, stopSpeed;

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
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
