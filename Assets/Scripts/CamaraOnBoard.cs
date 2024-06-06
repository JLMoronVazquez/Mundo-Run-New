using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraOnBoard : MonoBehaviour
{
    public Camaras camara;

    public MovimientoPMapita movimientopersonajeMapa;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movimientopersonajeMapa.speedAcensor = 5f;
            camara.Camaraf1 = false;
            camara.Camaraonboard = true;
            camara.transitionSpeed = 50;
            StartCoroutine("MovimientoObBoard");

        }

    }
    IEnumerator MovimientoObBoard()
    {
        yield return new WaitForSeconds(0.3f);
        camara.transitionSpeed = 1000;





    }
}
