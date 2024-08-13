using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrowScript : MonoBehaviour
{
    public GameObject packagePrefab;
    public float lifeSpan;
    public float maxOffsetUp;
    public float distanceToMaxOffset;
    public float throwForce;
    public Rigidbody playerRb;

    private GameObject package;
    private Rigidbody packageRb;
    private float lifeTimer;

    public void Start()
    {
        package = Instantiate(packagePrefab);
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

                Vector3 target = hit.point;
                target.y += GetOffset( target );

                Vector3 direction = (target - transform.position).normalized;
                packageRb.AddForce(direction * throwForce, ForceMode.Impulse);
                //packageRb.velocity = packageRb.velocity + playerRb.velocity;
                
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

    private float GetOffset( Vector3 target )
    {
        float offset = maxOffsetUp;

        float dist = Vector3.Distance(target, transform.position);
        if(dist < distanceToMaxOffset)
        {
            offset = ((dist/distanceToMaxOffset) * (dist/distanceToMaxOffset)) * maxOffsetUp;
        }

        return offset;
    }

}



