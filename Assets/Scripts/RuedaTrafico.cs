using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaTrafico : MonoBehaviour
{
    public Transform RuedaDI;
    public Transform RuedaDD;
    public Transform RuedaTI;
    public Transform RuedaTD;


    void Start()
    {

    }


    void Update()
    {
        RuedaDI.transform.Rotate(new Vector3(0f, 0f, -150) * Time.deltaTime);
        RuedaDD.transform.Rotate(new Vector3(0f, 0f, -150) * Time.deltaTime);
        RuedaTI.transform.Rotate(new Vector3(0f, 0f, -150) * Time.deltaTime);
        RuedaTD.transform.Rotate(new Vector3(0f, 0f, -150) * Time.deltaTime);
    }
}
