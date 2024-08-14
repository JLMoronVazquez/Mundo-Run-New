using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTr;
    public float stiffness;
    public float offsetZ;

    public void Update()
    {
        transform.DOMoveZ(playerTr.position.z - offsetZ, stiffness);
    }
}
