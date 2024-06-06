using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trafico : MonoBehaviour
{
    public float speedRot = 20;

    public Transform VelocidadTrafico;


    void Start()
    {

    }


    void Update()
    {


        VelocidadTrafico.transform.Rotate(new Vector3(0f, 0f, +speedRot) * Time.deltaTime);

    }
}
