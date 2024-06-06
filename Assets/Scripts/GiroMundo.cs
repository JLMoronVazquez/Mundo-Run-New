using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroMundo : MonoBehaviour
{
    //La velocidad normal es 10
    public float speedRot = 0;

    public Transform Mundo;


    void Start()
    {

    }


    void Update()
    {


        Mundo.transform.Rotate(new Vector3(-speedRot, 0f, 0f) * Time.deltaTime);

    }
}
