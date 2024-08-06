using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowScript : MonoBehaviour
{
    public GameObject package;
    public float lifeSpan;
    public float throwForce;
    public LayerMask layerGound;

    private Rigidbody packageRb;
    private float lifeTimer;

    public void Start()
    {
        package.SetActive(false);
        packageRb = package.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowPackage();
        CountTimer();
    }

    public void ThrowPackage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, layerGound))
            {
                // Check if the raycast hit the plane (or any collider attached to the plane)

                // Get the point of collision
                package.transform.position = hit.point;
                package.transform.position = hit.transform.position;
                package.transform.rotation = transform.rotation;
                package.SetActive(true);
                packageRb.velocity = Vector3.forward * throwForce;
                lifeTimer = lifeSpan;
            }
        }
    }

    public void CountTimer()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0)
        {
            package.SetActive(false);
        }
    }

}



