using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FollowPlayerRb : MonoBehaviour
{
    public Transform playerTr;
    public float stiffness;
    public float offsetZ;

    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        rb.DOMoveZ(playerTr.position.z - offsetZ, stiffness);
    }
}
