using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialInicioTiempo : MonoBehaviour
{
    public GameObject tutorial;

    public Pause pulsarPause;

    public GameObject personajeInicio;
    public GameObject personajePrincipal;

    void Start()
    {

    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulsarPause.puedePulsar = false;


            Time.timeScale = 0;
            tutorial.SetActive(true);


            personajePrincipal.SetActive(true);
            Destroy(personajeInicio);





        }
    }
}
