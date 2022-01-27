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

        /*if (Input.GetKeyDown(KeyCode.Space) && !_inAir)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _inAir = true;
        }*/
    }
    public void ButtonJump()
    {
        if (!_inAir)
        {
            _inAir = true;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
        }
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
