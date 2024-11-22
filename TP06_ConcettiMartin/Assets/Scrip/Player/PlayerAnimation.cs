using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerBody;
    private PlayerShoot playerShoot;


    private bool isAttacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        playerShoot = GetComponent<PlayerShoot>();

    }

    void Update()
    {
        SetRunAnimation();
        SetJumpAnimation();
        SetAttackingAnimation();

    }

    private void SetRunAnimation()
    {
        animator.SetFloat("MovementSpeed", Mathf.Abs(playerBody.velocity.x));
    }

    private void SetJumpAnimation()
    {
        animator.SetFloat("JumpSpeed", Mathf.Abs(playerBody.velocity.y));
    }
    private void SetAttackingAnimation()
    {
        isAttacking = playerShoot.GetIsAttacking();
       
        animator.SetBool("IsAttacking", isAttacking);


    }
}
