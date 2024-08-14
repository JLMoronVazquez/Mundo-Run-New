using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactiva : MonoBehaviour
{
   
    public GameObject deactiveZone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            
            deactiveZone.SetActive(false);


        }

    }
}
