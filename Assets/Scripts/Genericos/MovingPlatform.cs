using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public bool changeRotation;
    public float timeToMove;
    public Transform targetPos;


    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(targetPos.position, timeToMove).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
    }
}
