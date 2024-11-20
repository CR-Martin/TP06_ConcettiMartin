using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] private PlayerSO entityData;

    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private Vector2 collisionBoxSize;
    [SerializeField] private float jumpDelayTime = 0.7f;

    private Rigidbody2D rigidbody2D;
    private int maxJumps;
    private int currentJumps = 0;
    private bool isGrounded;
    private bool canJump = true;
    private float horizontalMovement;
    private const float NormalSpeed = 1.0f;
    private const float AirSpeedModifier = 0.5f;
    private float jumpTimer = 0;
    private bool isFalling = false;

    private bool facingRight = true;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        maxJumps = entityData.StartJumpsAmount;
    }

    private void FixedUpdate()
    {
        Move();
        CheckGrounded();
    }

    private void Update()
    {
        JumpHandler();
    }

    private void Move()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        horizontalMovement *= isGrounded ? NormalSpeed : AirSpeedModifier;


        if (horizontalMovement > 0)
        {
            Flip();
        }
        else if (horizontalMovement < 0)
        {
            Flip();
        }

        Vector2 speed = new Vector2(horizontalMovement * (entityData.MovementSpeed), rigidbody2D.velocity.y);
        rigidbody2D.velocity = speed;
    }

    private void Flip()
    {
        if ((horizontalMovement < 0 && facingRight) || (horizontalMovement > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void JumpDelay()
    {
        if (!canJump)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpDelayTime)
            {
                canJump = true;
            }
        }
    }
    private void JumpHandler()
    {
        JumpDelay();
        if (rigidbody2D.velocity.y <= 0)
        {
            isFalling = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump && currentJumps < maxJumps)
        {
            currentJumps++;
            canJump = false;
            jumpTimer = 0;
            isFalling = false;
            Jump();
        }

    }
    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * entityData.JumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D hit = Physics2D.OverlapBox(feetPosition.position, collisionBoxSize, 0, jumpLayer);
        isGrounded = hit != null;

        if (isGrounded && isFalling)
        {
            currentJumps = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(feetPosition.position, collisionBoxSize);
    }

    public int GetMaxJumps()
    {
        return maxJumps;
    }

    public void SetMaxJumps(int value)
    {
        this.maxJumps = value;
    }

}
