using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSegment : MonoBehaviour
{
    public GameObject segment;
    public bool activate;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            segment.SetActive(activate);
        }
    }
}
