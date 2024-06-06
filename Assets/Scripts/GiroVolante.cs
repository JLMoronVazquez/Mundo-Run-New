using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroVolante : MonoBehaviour
{
    private float targetRotationZI = -20f;
    private float targetRotationZD = 20f;
    private float releaseRotationZ = 0f;

    public FuncionF1 funcionf1;


    private void Start()
    {



    }



    private void Update()
    {

        if (Input.GetKey(KeyCode.A) && funcionf1.GiraLasRuedas == false)
        {


            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetRotationZI);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKey(KeyCode.D) && funcionf1.GiraLasRuedas == false)
        {


            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetRotationZD);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKeyUp(KeyCode.A))
        {


            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, releaseRotationZ);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKeyUp(KeyCode.D))
        {


            Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, releaseRotationZ);
            transform.rotation = Quaternion.Euler(newRotation);


        }
    }
}
