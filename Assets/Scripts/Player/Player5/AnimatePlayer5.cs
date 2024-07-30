using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimatePlayer5 : MonoBehaviour
{
    private Animator anim;
    public Player.PlayerV5 playerLogic;
    public Rigidbody rbOfPlayer;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        anim.SetBool( "isJumping", playerLogic.isJumping);
        anim.SetBool( "isRolling", playerLogic.isRolling);
        anim.SetBool( "isTripping", playerLogic.isTripping);

        Vector3 velPlayer = rbOfPlayer.velocity;
        float velocityXZ =  Mathf.Abs(velPlayer.x) + Mathf.Abs(velPlayer.z );
        anim.SetBool( "isRunning", velocityXZ > 0.2f && playerLogic.CheckGround() );
    }
}
