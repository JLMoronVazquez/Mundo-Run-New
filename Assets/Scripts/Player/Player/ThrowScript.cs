using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public Cruzeta cruz;
    public GameObject packagePrefab;
    public Rigidbody playerRb;
    public float lifeSpan;
    public float maxOffsetUp, distanceToMaxOffset;
    public float throwForce;
    public float delayTime;
    public LayerMask IgnoreMe;

    private GameObject package;
    private Rigidbody packageRb;
    private float lifeTimer, delayTimer;
    [HideInInspector] public bool isThrowing;

    public void Start()
    {
        cruz.readyTime = lifeSpan;
        cruz.IgnoreMe = IgnoreMe;
        isThrowing = false;
        package = Instantiate(packagePrefab);
        package.SetActive(false);
        packageRb = package.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CountTimer();
        CheckThrow();
    }

    public void CheckThrow()
    {
        if (Input.GetMouseButtonDown(0) && lifeTimer < 0)
        {
            lifeTimer = lifeSpan;
            delayTimer = delayTime;
            isThrowing = true;
        }
        else
        {
            isThrowing = false;
        }

        delayTimer -= Time.deltaTime;
        if (delayTimer < 0 && lifeTimer > 0)
        {
            ThrowPackage();
        }
    }

    public void ThrowPackage()
    {
        delayTimer = 100;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float rayDistance = 100;

        if (Physics.Raycast(ray, out hit, rayDistance, ~IgnoreMe ))
        {
            packageRb.velocity = Vector3.zero;
            package.SetActive(true);

            package.transform.position = transform.position;
            //package.transform.LookAt(hit.point);

            Vector3 target = hit.point;
            target.y += GetOffset(target);

            Vector3 direction = (target - transform.position).normalized;
            packageRb.AddForce(direction * throwForce, ForceMode.Impulse);
            //packageRb.velocity = packageRb.velocity + playerRb.velocity;
        }

        cruz.CantThrow();
        
    }

    public void CountTimer()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0)
        {
            package.SetActive(false);
        }
    }

    private float GetOffset(Vector3 target)
    {
        float offset = maxOffsetUp;

        float dist = Vector3.Distance(target, transform.position);
        if (dist < distanceToMaxOffset)
        {
            offset = ((dist / distanceToMaxOffset) * (dist / distanceToMaxOffset)) * maxOffsetUp;
        }

        return offset;
    }

}



