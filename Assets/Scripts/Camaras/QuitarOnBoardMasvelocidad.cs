using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarOnBoardMasvelocidad : MonoBehaviour
{
    public Camaras camara;
    public FuncionF1 funcionf1;

    public GameObject ActivadorCañon;

    public Vector3 newPosition;




    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            ActivadorCañon.SetActive(true);
            transform.position = newPosition;
            camara.Camaraf1 = false;
            camara.Camaraonboard = false;
            camara.Camaraprincipal = true;
            camara.transitionSpeed = 1;
            funcionf1.AceleradorCoche = false;
            funcionf1.MaxVelocidadCoche = true;
            StartCoroutine("PararMotorRoto");

        }

    }
    IEnumerator PararMotorRoto()
    {
        yield return new WaitForSeconds(5f);
        funcionf1.MaxVelocidadCoche = false;
        funcionf1.RoturaMotorCoche = true;






    }
}
