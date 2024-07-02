using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public PlayerMov plyMov;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Tierra"))
        {
            plyMov.isJumping = false;
        }

        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            plyMov.isJumping = false;
            plyMov.isOnPlatform = true;
        }

        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            plyMov.worldRotation.speedRot = plyMov.worldRotation.tripSpeed;
            plyMov.isJumping = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            plyMov.isOnPlatform = false;
        }

        if (other.GetComponent<Collider>().CompareTag("Tropiezo"))
        {
            plyMov.worldRotation.speedRot = plyMov.worldRotation.normalSpeed;
        }
    }
}
