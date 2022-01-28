using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public int jumpPower;
    public int gravityScale;
    public int fallingGravityScale;
    public Rigidbody2D rb;
    private bool _inAir;
    private bool _buttonIsPressed;
    private float _savedTime;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        if (Time.time - _savedTime > 0.05 && _buttonIsPressed)
        {
            _savedTime = Time.time;
            ButtonJump();
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && !_inAir)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _inAir = true;
        }*/
    }
    private void ButtonJump()
    {
        if (!_inAir)
        {
            _inAir = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            

        }
    }

    public void PressButton()
    {
        _buttonIsPressed = true;
    }

    public void UnpressButton()
    {
        _buttonIsPressed = false;
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0 && collision.gameObject.CompareTag("ground"))
        {
            _inAir = false;
        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) 
        {
            _inAir = true;
        }
        
    }
}
