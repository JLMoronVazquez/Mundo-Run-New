using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Cruzeta : MonoBehaviour
{
    public float rotateSpeed, stiffness;
    public Color colorReady, colorNotReady;
    public Material matCruz;

    [HideInInspector] public float readyTime;
    [HideInInspector] public LayerMask IgnoreMe;
    [HideInInspector] public Vector3 posToMove;

    private bool ready = true;
    private GameObject mainCamera;
    private float readyTimer;


    public void Start()
    {
        mainCamera = Camera.main.gameObject;
        readyTimer = 0;
        matCruz.SetColor("_BaseColor", colorReady);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        if (ready)
        {
            transform.GetChild(0).transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
        else
        {
            readyTimer -= Time.deltaTime;
            if( readyTimer < 0 )
            {
                ready = true;
                matCruz.SetColor("_BaseColor", colorReady);
            }
        }
    }



    public void UpdatePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float rayDistance = 100;

        if (Physics.Raycast(ray, out hit, rayDistance, ~IgnoreMe))
        {
            transform.DOMove(hit.point + Vector3.back * 0.1f, stiffness);
            transform.DOLookAt(mainCamera.transform.position, stiffness);
        }
    }

    public void CantThrow()
    {
        ready = false;
        readyTimer = readyTime;
        matCruz.SetColor("_BaseColor", colorNotReady);
    }
}
