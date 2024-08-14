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


    // Start is called before the first frame update
    void Start()
    {
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
}
