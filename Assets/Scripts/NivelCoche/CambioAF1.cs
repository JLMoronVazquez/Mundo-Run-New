using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAF1 : MonoBehaviour
{
    public GameObject Protagonista;
    public GameObject F1;


    public RotateWorld PararMundo;
    public FuncionF1 funcionf1;
    public Camaras camara;


    public Animator CerrarCochera;
    public Animator AbrirCochera;

    public GameObject CartelDesguace;


    public MovimientoPMapita movimientopersonajeMapa;

    public AudioSource sonidoAbrirCochera;

    public AudioSource sonidoF1salida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movimientopersonajeMapa.speedAcensor = 1.8f;

            sonidoAbrirCochera.Play();

            F1.SetActive(true);
            Protagonista.SetActive(false);
            PararMundo.speedRot = 0;

            CerrarCochera.Play("CerrarCochera");
            AbrirCochera.Play("AbrirCochera");
            Destroy(CartelDesguace);

            StartCoroutine("CamaraF1");
            StartCoroutine("AndaElF1");

        }

    }
    IEnumerator CamaraF1()
    {
        yield return new WaitForSeconds(2f);
        camara.Camaraf1 = true;





    }

    IEnumerator AndaElF1()
    {
        yield return new WaitForSeconds(5f);
        funcionf1.AceleradorCoche = true;
        sonidoF1salida.Play();





    }
}
