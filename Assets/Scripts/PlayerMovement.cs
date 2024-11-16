using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movSpeed;
    
    private float speedX,speedY;
    
    private SpriteRenderer _spriteRenderer;
    
    private Rigidbody2D _rb;
    
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rb.velocity = new Vector2(speedX, speedY);
        UpdateSpriteDirection();
    }
    
    void UpdateSpriteDirection()
    {
        
        if (speedX > 0 && speedY > 0)
        {
            _spriteRenderer.sprite = spriteRight;
        }
        else if (speedX > 0 && speedY < 0)
        {
            _spriteRenderer.sprite = spriteRight;
        }
        else if (speedX < 0 && speedY > 0)
        {
            _spriteRenderer.sprite = spriteLeft;
        }
        else if (speedX < 0 && speedY < 0)
        {
            _spriteRenderer.sprite = spriteLeft;
        }
        
    }
}
