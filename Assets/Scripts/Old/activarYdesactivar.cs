using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarYdesactivar : MonoBehaviour
{
    public GameObject activeZone;
    public GameObject deactiveZone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            activeZone.SetActive(true);
            deactiveZone.SetActive(false);

     
        }

    }
}
