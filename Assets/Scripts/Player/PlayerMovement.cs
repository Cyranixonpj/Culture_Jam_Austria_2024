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
    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb.freezeRotation = true;
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rb.velocity = new Vector2(speedX, speedY);

        Debug.Log($"speedX: {speedX}, speedY: {speedY}");

        walking = speedX != 0 || speedY != 0;

        if (walking)
        {
            _audioManager.StartWalk();
        }
        else
        {
            _audioManager.StopWalk();
        }

        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        Debug.Log($"speedX: {speedX}, speedY: {speedY}, walking: {walking}");

        if (speedX != 0 || speedY != 0) // Zmiana tylko jeśli poruszamy się
        {
            walking = true;
            _animator.SetBool("MDown", false);
            _animator.SetBool("MUp", false);
            _animator.SetBool("MRight", false); // Resetuj przed ustawieniem nowych animacji

            if (speedX != 0)
            {
                _animator.SetBool("MRight", true);
                FlipSprite(speedX < 0);
            }
            else if (speedY > 0)
            {
                _animator.SetBool("MUp", true);
            }
            else if (speedY < 0)
            {
                _animator.SetBool("MDown", true);
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
        if (_isFacingRight != !flip)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 theScale = _spriteRenderer.transform.localScale;
            theScale.x *= -1;
            _spriteRenderer.transform.localScale = theScale;
        }
    }
}
