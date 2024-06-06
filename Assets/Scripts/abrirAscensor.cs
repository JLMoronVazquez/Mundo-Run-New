using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirAscensor : MonoBehaviour
{
    public Animator AscensorPuertaD1;
    public Animator AscensorPuertaI1;
    public Animator AscensorPuertaD2;
    public Animator AscensorPuertaI2;

    public GameObject sonidoAbrirAscensor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            sonidoAbrirAscensor.SetActive(true);

            AscensorPuertaD1.Play("AscensorPuertaD1");
            AscensorPuertaI1.Play("AscensorPuertaI1");
            AscensorPuertaD2.Play("AscensorPuertaD2");
            AscensorPuertaI2.Play("AscensorPuertaI2");

        }

    }
}
