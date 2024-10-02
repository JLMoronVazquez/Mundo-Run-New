using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject currentSegment;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentSegment.transform.GetChild(0).gameObject.SetActive(false);
            other.gameObject.GetComponent<CheckPoints>().Respawn();
        }
    }
}
