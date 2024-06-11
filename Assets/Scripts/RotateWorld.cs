using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float speedRot, normalSpeed, rollSpeed, tripSpeed, carSpeed, boatSpeed, stopSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 0f, -speedRot) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
