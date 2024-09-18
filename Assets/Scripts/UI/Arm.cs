using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Transform posDeactivated, posActivated;
    public float timeToMove;

    public void ActivateArm()
    {
        transform.DOMove(posActivated.position, timeToMove);
    }

    public void DeActivateArm()
    {
        transform.DOMove(posDeactivated.position, timeToMove);
    }
}
