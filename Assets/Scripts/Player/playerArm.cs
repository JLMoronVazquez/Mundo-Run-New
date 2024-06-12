using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerArm : MonoBehaviour
{
    public PlayerMov plyMov;
    public bool isRight;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            if (isRight)
            {
                plyMov.somethingRight = true;
            }
            else
            {
                plyMov.somethingLeft = true;
            }
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            if (isRight)
            {
                plyMov.somethingRight = true;
            }
            else
            {
                plyMov.somethingLeft = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            if (isRight)
            {
                plyMov.somethingRight = false;
            }
            else
            {
                plyMov.somethingLeft = false;
            }
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            if (isRight)
            {
                plyMov.somethingRight = false;
            }
            else
            {
                plyMov.somethingLeft = false;
            }
        }
    }
}
