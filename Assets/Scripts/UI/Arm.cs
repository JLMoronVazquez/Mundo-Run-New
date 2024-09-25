using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Transform posDeactivated, posActivated;
    [HideInInspector] public float timeToMove;

    [HideInInspector] public bool isActivated;

    public void ActivateArm()
    {
        transform.DOLocalMove(posActivated.localPosition, timeToMove).SetUpdate(true).OnComplete(ArmActivationComplete);
    }

    public void DeActivateArm()
    {
        transform.DOLocalMove(posDeactivated.localPosition, timeToMove).SetUpdate(true);
        isActivated = false;
    }

    public void ArmActivationComplete()
    {
        isActivated = true;
    }
}
