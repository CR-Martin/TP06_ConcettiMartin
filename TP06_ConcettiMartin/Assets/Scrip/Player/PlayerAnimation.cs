using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerBody;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetRunAnimation();
        SetJumpAnimation();
    }

    private void SetRunAnimation()
    {
        animator.SetFloat("MovementSpeed", Mathf.Abs(playerBody.velocity.x));
    }

    private void SetJumpAnimation()
    {
        animator.SetFloat("JumpSpeed", Mathf.Abs(playerBody.velocity.y));
    }
}
