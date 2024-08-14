using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activa : MonoBehaviour
{
    public GameObject activeZone;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            activeZone.SetActive(true);
            


        }

    }
}
