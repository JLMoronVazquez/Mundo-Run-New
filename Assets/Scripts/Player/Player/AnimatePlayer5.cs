using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimatePlayer5 : MonoBehaviour
{
    private Animator anim;
    public Player.PlayerMov playerLogic;
    public ThrowScript  throwLogic;
    public Rigidbody rbOfPlayer;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        anim.SetBool("isJumping", playerLogic.isJumping);
        anim.SetBool("isRolling", playerLogic.isRollInCooldown);
        anim.SetBool("isTripping", playerLogic.isTripping && playerLogic.isRunnig);

        Vector3 velPlayer = rbOfPlayer.velocity;
        float velocityXZ = Mathf.Abs(velPlayer.x) + Mathf.Abs(velPlayer.z);
        anim.SetBool("isRunning", playerLogic.isRunnig && playerLogic.CheckGround());
        
        anim.SetBool("isFalling", !playerLogic.CheckGround() && !playerLogic.isJumping);

        anim.SetBool("isShooting", throwLogic.isThrowing);
    }
}
