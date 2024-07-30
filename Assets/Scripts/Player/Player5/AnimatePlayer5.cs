using System.Collections;
using System.Collections.Generic;
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
        anim.SetBool( "isRunning", rbOfPlayer.velocity.magnitude > 0.2f && playerLogic.CheckGround() );
    }
}
