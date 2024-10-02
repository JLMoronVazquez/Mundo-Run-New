using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveWhenHit : MonoBehaviour
{
    public bool changeRotation;
    public float timeToMove;
    public Transform targetPos;

    private bool hasMoved;
    Vector3 originalPos;
    Vector3 originalRotation;


    // Start is called before the first frame update
    void Awake()
    {
        originalPos = transform.localPosition;
        originalRotation = transform.localEulerAngles;
        hasMoved = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasMoved && collision.gameObject.CompareTag("Paquete"))
        {
            hasMoved = true;
            transform.DOMove(targetPos.position, timeToMove);

            if (changeRotation)
            {
                transform.DORotateQuaternion(targetPos.rotation, timeToMove);
            }
        }
    }

    void OnEnable()
    {
        hasMoved = false;
        transform.localPosition = originalPos;
        transform.localEulerAngles = originalRotation;
    }
}
