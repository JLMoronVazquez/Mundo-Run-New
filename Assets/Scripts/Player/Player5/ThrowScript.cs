using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowScript : MonoBehaviour
{
    public GameObject package;
    public float lifeSpan;
    public float throwForce;
    public LayerMask layerGound;
    public Rigidbody playerRb;

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
        if (Input.GetMouseButtonDown(0) && lifeTimer < 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float rayDistance = 100;
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.yellow);
      
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                packageRb.velocity = Vector3.zero;
                package.SetActive(true);

                package.transform.position = transform.position;
                //package.transform.LookAt(hit.point);

                Vector3 direction = (hit.point - transform.position).normalized;
                packageRb.AddForce(direction * throwForce, ForceMode.Impulse);
                packageRb.velocity = packageRb.velocity + playerRb.velocity;
                
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



