using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroRueda : MonoBehaviour
{
    public FuncionF1 funcionf1;

    public bool VelocidadRueda = true;


    public Transform RuedaDI;
    public Transform RuedaDD;
    public Transform RuedaTI;
    public Transform RuedaTD;




    void Start()
    {


    }


    void Update()
    {
        if (VelocidadRueda == true)
        {
            RuedaDI.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 10) * Time.deltaTime);
            RuedaDD.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 10) * Time.deltaTime);
            RuedaTI.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 10) * Time.deltaTime);
            RuedaTD.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 10) * Time.deltaTime);
        }
        if (VelocidadRueda == false)
        {
            RuedaDI.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 5) * Time.deltaTime);
            RuedaDD.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 5) * Time.deltaTime);
            RuedaTI.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 5) * Time.deltaTime);
            RuedaTD.transform.Rotate(new Vector3(0f, 0f, funcionf1.VelocidadF1 * 5) * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Trafico"))
        {
            VelocidadRueda = false;

        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trafico"))
        {

            VelocidadRueda = true;

        }
    }
}
