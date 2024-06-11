using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarRueda : MonoBehaviour
{
    private float targetRotationYI = -100f;
    private float targetRotationX = 180f;
    private float targetRotationYD = -80f;
    private float releaseRotationY = -90f;

    public FuncionF1 funcionf1;


    private void Start()
    {



    }



    private void Update()
    {

        if (Input.GetKey(KeyCode.A) && funcionf1.GiraLasRuedas == false)
        {


            Vector3 newRotation = new Vector3(targetRotationX, targetRotationYI, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKey(KeyCode.D) && funcionf1.GiraLasRuedas == false)
        {


            Vector3 newRotation = new Vector3(targetRotationX, targetRotationYD, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKeyUp(KeyCode.A))
        {


            Vector3 newRotation = new Vector3(targetRotationX, releaseRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(newRotation);


        }
        if (Input.GetKeyUp(KeyCode.D))
        {


            Vector3 newRotation = new Vector3(targetRotationX, releaseRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(newRotation);


        }
    }
}
