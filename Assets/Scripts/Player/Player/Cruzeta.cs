using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cruzeta : MonoBehaviour
{
    public float rotateSpeed, stiffness;
    public Color colorReady, colorNotReady;
    public Renderer rd;
    [HideInInspector] public float readyTime;
    private float readyTimer;
    public LayerMask IgnoreMe;

    public Vector3 posToMove;
    private bool ready = true;
    private GameObject mainCamera;


    public void Start()
    {
        mainCamera = Camera.main.gameObject;
        readyTimer = 0;
        rd.material.color = colorReady;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        if (ready)
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }



    public void UpdatePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float rayDistance = 100;

        if (Physics.Raycast(ray, out hit, rayDistance, ~IgnoreMe ))
        {
            transform.DOMove(hit.point + Vector3.back * 0.1f, stiffness);
            transform.DOLookAt(mainCamera.transform.position, stiffness);
        }
    }
}
