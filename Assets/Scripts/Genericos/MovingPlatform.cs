using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public bool changeRotation;
    public float timeToMove;
    public Transform targetPos;

    private bool isForward = true;
    private Vector3 originalPos;
    private float timerToMove;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPos = transform.position;
        timerToMove = 0;
        rb.DOMove(targetPos.position, timeToMove).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerV5>().rbOfGround = this.rb;
        }
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerV5>().rbOfGround = null;
        }
    }
}
