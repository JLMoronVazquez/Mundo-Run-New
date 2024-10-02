using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Vector3 currCheckpointPos;
    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currCheckpointPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currCheckpointPos = other.gameObject.transform.position;
        }
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        transform.position = currCheckpointPos;
    }
}
