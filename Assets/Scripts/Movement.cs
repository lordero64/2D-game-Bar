using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _feetPosution;
    [SerializeField] private LayerMask _ground;

    private Rigidbody2D _rigitBody2D;
    private Animator _animator;
    private bool _isGrounded;
    private bool _isLookingForward = true;
    private float _groundRadius = 0.2f;
    private float _moveInput;
    private int _speedAimation = 2;

    private readonly int _speedHash = Animator.StringToHash("Speed");
    private readonly int _jumpHash = Animator.StringToHash("IsJumping");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigitBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPosution.position, _groundRadius, _ground);
        _moveInput = Input.GetAxisRaw("Horizontal");

        Flip();

        if (_isGrounded == false)
        {
            _animator.SetBool(_jumpHash, true);
        }
        else
        {
            _animator.SetBool(_jumpHash, false);
        }

        if (_moveInput != 0)
        {
            _animator.SetFloat(_speedHash, _speedAimation);
        }
        else
        {
            _animator.SetFloat(_speedHash, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigitBody2D.velocity = new Vector2(_rigitBody2D.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _rigitBody2D.velocity = new Vector2(_moveInput * _speed, _rigitBody2D.velocity.y);
    }

    private void Flip()
    {
       if ((_isLookingForward && _moveInput < 0f) || (!_isLookingForward && _moveInput > 0f))
        {            
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            _isLookingForward = !_isLookingForward;
        }
    }
}
