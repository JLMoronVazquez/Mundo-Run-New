using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LeftArm : Arm
{
    public float responsivenes;
    public Vector4 limits;
    public float clickDuration;
    public float clickDeep;

    private Vector3 positionPreClick;

    public void Update()
    {
        if (isActivated)
        {
            HoverHand();
            if (Input.GetMouseButtonDown(0))
            {
                Click();
            }
        }
    }


    public void Click()
    {
        positionPreClick = transform.localPosition;
        Vector3 posClick = transform.localPosition;
        posClick.z += clickDeep;
        transform.DOLocalMove(posClick, clickDuration).SetUpdate(true);
    }


    public void HoverHand()
    {
        Vector3 mouseMov = transform.localPosition;
        mouseMov.x += Input.GetAxis("Mouse X");
        mouseMov.y += Input.GetAxis("Mouse Y");
        CheckLimitis(ref mouseMov);
        transform.DOLocalMove(mouseMov, responsivenes).SetUpdate(true);
    }


    public void CheckLimitis(ref Vector3 mouseMov)
    {
        //print("posicion: " + mouseMov.x);
        if (mouseMov.x > limits.x)
        {
            mouseMov.x = limits.x;
        }

        if (mouseMov.x < limits.y)
        {
            mouseMov.x = limits.y;
        }

        if (mouseMov.y > limits.z)
        {
            mouseMov.y = limits.z;
        }

        if (mouseMov.y < limits.w)
        {
            mouseMov.y = limits.w;
        }
    }
}
