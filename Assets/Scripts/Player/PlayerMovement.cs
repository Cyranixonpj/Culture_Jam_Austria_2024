using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movSpeed;
    
    private float speedX,speedY;
    
    private SpriteRenderer _spriteRenderer;
    
    private Rigidbody2D _rb;
    
    private Animator _animator;
    
    private bool _isFacingRight = true;
    
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rb.velocity = new Vector2(speedX, speedY);
       UpdateAnimations();
    }
    
    void UpdateAnimations()
    {
        if (speedX !=0 )
        {
            if (speedX >0)
            {
                _animator.SetTrigger("IsSide");
                FlipSprite(false);
            }
            else
            {
                _animator.SetTrigger("IsSide");
                FlipSprite(true);
            }
        }
    }
    private void FlipSprite(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }
    
}
