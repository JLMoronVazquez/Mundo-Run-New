using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public PlayerMov plyMov;
    private int obstaclesColiding = 0;

    
    public void OnTriggerEnter(Collider other)
    {
        print("hola");
        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            obstaclesColiding++;
            plyMov.worldRotation.speedRot = plyMov.worldRotation.stopSpeed;
            plyMov.playerSpeed = plyMov.slowSpeed;
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            obstaclesColiding++;
            plyMov.worldRotation.speedRot = plyMov.worldRotation.stopSpeed;
            plyMov.playerSpeed = plyMov.slowSpeed;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        print("eo");
        if (other.GetComponent<Collider>().CompareTag("Untagged"))
        {
            obstaclesColiding--;
            if (obstaclesColiding == 0)
            {
                plyMov.worldRotation.speedRot = plyMov.worldRotation.normalSpeed;
                plyMov.playerSpeed = plyMov.normalSpeed;
            }
        }

        if (other.GetComponent<Collider>().CompareTag("Agachate"))
        {
            obstaclesColiding--;
            if (obstaclesColiding == 0)
            {
                plyMov.worldRotation.speedRot = plyMov.worldRotation.normalSpeed;
                plyMov.playerSpeed = plyMov.normalSpeed;
            }
        }
    }
}
