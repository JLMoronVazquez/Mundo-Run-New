using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadContiF1 : MonoBehaviour
{
    public FuncionF1 funcionesF1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            funcionesF1.FrenaF1 = 3;


        }

    }
}
