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
    private AudioManager _audioManager;
    private bool walking;

 

    
    
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _rb.freezeRotation = true;
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rb.velocity = new Vector2(speedX, speedY);
       UpdateAnimations();
       if (walking == true)
       {
           _audioManager.StartWalk();
       }
       else
       {
           _audioManager.StopWalk();
       }
    }
    
    
    
    void UpdateAnimations()
    {

        walking = true;
        if (speedX != 0)
        {
            _animator.SetBool("MDown", false);
            _animator.SetBool("MUp", false);
            _animator.SetBool("MRight", true);
            
           // _spriteRenderer.sprite = sideSprite;
            FlipSprite(speedX < 0);
        }
        else if (speedY != 0)
        {
            if (speedY > 0)
            {
                _animator.SetBool("MDown", false);
                _animator.SetBool("MUp", true);
                _animator.SetBool("MRight", false);
            }
            else
            {
                _animator.SetBool("MDown", true);
                _animator.SetBool("MUp", false);
                _animator.SetBool("MRight", false);
            }
        }
        else
        {
            walking = false;
            _animator.SetBool("MDown", false);
            _animator.SetBool("MUp", false);
            _animator.SetBool("MRight", false);
        }
    }
    private void FlipSprite(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }
    
}