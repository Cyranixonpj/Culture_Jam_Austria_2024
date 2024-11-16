using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movSpeed;
    
    private float speedX,speedY;
    
    
    private Rigidbody2D _rb;
    
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rb.velocity = new Vector2(speedX, speedY);
    }
}
