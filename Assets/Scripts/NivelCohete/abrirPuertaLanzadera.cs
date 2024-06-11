using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuertaLanzadera : MonoBehaviour
{
    public Animator abrirLanzadera;
    public GameObject sonidoPuertaLanzadera;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            sonidoPuertaLanzadera.SetActive(true);

            abrirLanzadera.Play("abrirlanzadera");

        }

    }
}
