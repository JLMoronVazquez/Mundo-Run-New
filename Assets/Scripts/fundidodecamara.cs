using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fundidodecamara : MonoBehaviour
{
    public GameObject sonidoCampana;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sonidoCampana.SetActive(true);

        }

    }
}
