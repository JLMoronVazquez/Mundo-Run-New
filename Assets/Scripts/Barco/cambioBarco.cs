using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioBarco : MonoBehaviour
{
    public GameObject Protagonista;
    public GameObject barco;


    public RotateWorld PararMundo;
    public FuncionBarco funcionBarco;
    public Camaras camara;



    public GameObject Cementerio;

    public MovimientoPMapita movimientopersonajeMapa;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movimientopersonajeMapa.speedAcensor = 3f;

            barco.SetActive(true);
            Protagonista.SetActive(false);
            PararMundo.speedRot = 0;



            Destroy(Cementerio);

            StartCoroutine("CamaraBarco");
            StartCoroutine("AndaElBarco");

        }

    }
    IEnumerator CamaraBarco()
    {
        yield return new WaitForSeconds(1f);
        camara.Camaraf1 = true;

    }

    IEnumerator AndaElBarco()
    {
        yield return new WaitForSeconds(0.5f);
        funcionBarco.AceleradorInicioBarco = true;

    }
}
