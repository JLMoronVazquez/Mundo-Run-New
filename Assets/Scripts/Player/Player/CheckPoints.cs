using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Vector3 currCheckpointPos;
    private Armazon currentArmazon;
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
            currentArmazon = other.gameObject.GetComponent<Armazon>();
        }
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        currentArmazon.currentSegment.transform.GetChild(0).gameObject.SetActive(false);
        currentArmazon.nextSegment.transform.GetChild(0).gameObject.SetActive(false);
        currentArmazon.previousSegment.transform.GetChild(0).gameObject.SetActive(false);
        currentArmazon.currentSegment.transform.GetChild(0).gameObject.SetActive(true);
        currentArmazon.nextSegment.transform.GetChild(0).gameObject.SetActive(true);
        currentArmazon.previousSegment.transform.GetChild(0).gameObject.SetActive(true);
        transform.position = currCheckpointPos;
    }
}
