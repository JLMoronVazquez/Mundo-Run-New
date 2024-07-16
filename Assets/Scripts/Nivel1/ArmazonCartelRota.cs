using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmazonCartelRota : MonoBehaviour
{
    public float speedRotation;
    public GameObject Cartel;

    // Update is called once per frame
    void Update()
    {
        Cartel.transform.Rotate(0, 0, speedRotation * Time.deltaTime);
    }
}
