using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPMapita : MonoBehaviour
{
    public float speedAcensor = 2;
    public bool andaPersonaje = false;
    public Transform personajeMapa;

    public RotateWorld PararMundo;


    void Start()
    {


    }


    void Update()
    {


        if (PararMundo.speedRot == 20)
        {

            Vector3 translation = new Vector3(0f, 0f, 0f);
            personajeMapa.transform.Translate(translation * Time.deltaTime);

        }
        else if (PararMundo.speedRot == 15)
        {

            Vector3 translation = new Vector3(2.5f, 0f, 0f);
            personajeMapa.transform.Translate(translation * Time.deltaTime);

        }
        else if (PararMundo.speedRot != 0)
        {

            Vector3 translation = new Vector3(speedAcensor, 0f, 0f);
            personajeMapa.transform.Translate(translation * Time.deltaTime);

        }



    }
}
