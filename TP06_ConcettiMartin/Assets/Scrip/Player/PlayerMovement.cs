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

    private Rigidbody2D _rigidbody2D;
    private int _maxJumps;
    private int _currentJumps = 0;
    private bool _isGrounded;
    private bool _canJump = true;
    private float _horizontalMovement;
    private const float NormalSpeed = 1.0f;
    private const float AirSpeedModifier = 0.5f;
    private float _jumpTimer = 0;
    private bool _isFalling = false;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxJumps = entityData.StartJumpsAmount;
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
        _horizontalMovement = Input.GetAxis("Horizontal");
        _horizontalMovement *= _isGrounded ? NormalSpeed : AirSpeedModifier;

       

        Vector2 speed = new Vector2(_horizontalMovement * (entityData.MovementSpeed), _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = speed;
    }


    private void JumpDelay()
    {
        if (!_canJump)
        {
            _jumpTimer += Time.deltaTime;

            if (_jumpTimer >= jumpDelayTime)
            {
                _canJump = true;
            }
        }
    }
    private void JumpHandler()
    {
        JumpDelay();
        if (_rigidbody2D.velocity.y <= 0)
        {
            _isFalling = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canJump && _currentJumps < _maxJumps)
        {
            _currentJumps++;
            _canJump = false;
            _jumpTimer = 0;
            _isFalling = false;
            Jump();
        }

    }
    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * entityData.JumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D hit = Physics2D.OverlapBox(feetPosition.position, collisionBoxSize, 0, jumpLayer);
        _isGrounded = hit != null;

        if (_isGrounded && _isFalling)
        {
            _currentJumps = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(feetPosition.position, collisionBoxSize);
    }

    public int GetMaxJumps()
    {
        return _maxJumps;
    }

    public void SetMaxJumps(int value)
    {
        this._maxJumps = value;
    }

}
