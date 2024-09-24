using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Transform posDeactivated, posActivated;
    public float timeToMove;

    [HideInInspector] public bool isActivated;

    public void ActivateArm()
    {
        transform.DOMove(posActivated.position, timeToMove).SetUpdate(true).OnComplete(ArmActivationComplete);
        
    }

    public void DeActivateArm()
    {
        transform.DOMove(posDeactivated.position, timeToMove).SetUpdate(true);
        isActivated = false;
    }

    public void ArmActivationComplete()
    {
        isActivated = true;
    }
}
