using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioProtagonista : MonoBehaviour
{
    public GameObject Protagonista;
    public GameObject barco;


    public RotateWorld PararMundo;
    //public FuncionBarco funcionBarco;
    public Camaras camara;




    public GameObject N5P2;





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            Protagonista.SetActive(true);

            barco.SetActive(false);
            PararMundo.speedRot = 0;



            Destroy(N5P2);

            StartCoroutine("CamaraBarco");
            StartCoroutine("AndaElBarco");

        }

    }
    IEnumerator CamaraBarco()
    {
        yield return new WaitForSeconds(1f);
        camara.Camaraprincipal = true;





    }

    IEnumerator AndaElBarco()
    {
        yield return new WaitForSeconds(0.5f);
        PararMundo.speedRot = 10;
        //funcionBarco.AceleradorInicioBarco = true;





    }
}
