using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    private CapsuleCollider2D touchingCollider;
    private Animator animator;
    public ContactFilter2D castFilter;

    private RaycastHit2D[] groundHits = new RaycastHit2D[5];
    public float groundDistance = 0.5f;

    [SerializeField]
    private bool _isGrounded;

    public bool isGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        isGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
