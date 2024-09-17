using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSegment : MonoBehaviour
{
    public GameObject segment;

    public void OnTriggerEnter(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            segment.SetActive(!segment.activeSelf);
        }
    }
}
