using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class LeftArm : Arm
{
    public float responsivenes;
    public Vector4 limits;
    public float clickDuration;
    public float clickDeep;

    private Vector3 positionPreClick;

    private float timerClick = 0;

    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void LateUpdate()
    {
        if (isActivated)
        {
            timerClick -= Time.unscaledDeltaTime;
            if (timerClick > 0)
            {
                return;
            }

            HoverHand();
            if (Input.GetMouseButtonDown(0))
            {
                timerClick = clickDuration * 2;
                Click();
            }
        }
    }


    public void Click()
    {
        positionPreClick = transform.localPosition;
        Vector3 posClick = transform.position;
        posClick.z += clickDeep;
        //print("pos: " + transform.position + " target: " + posClick);
        transform.DOMove(posClick, clickDuration).SetLoops(2, LoopType.Yoyo).SetUpdate(true);
        //rb.MovePosition( Vector3.zero );
        //transform.position = posClick;
    }


    public void HoverHand()
    {
        Vector3 mouseMov = transform.localPosition;
        mouseMov.x += Input.GetAxis("Mouse X") * responsivenes;
        mouseMov.y += Input.GetAxis("Mouse Y") * responsivenes;
        CheckLimitis(ref mouseMov);
        transform.localPosition = mouseMov;
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
