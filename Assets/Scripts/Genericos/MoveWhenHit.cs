using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveWhenHit : MonoBehaviour
{
    private bool hasMoved;
    public float timeToMove;
    public Transform targetPos;


    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if( !hasMoved && collision.gameObject.CompareTag("Paquete"))
        {
            hasMoved = true;
            transform.DOMove( targetPos.position, timeToMove );
            transform.DORotateQuaternion( targetPos.rotation, timeToMove );
        }
    }
}
