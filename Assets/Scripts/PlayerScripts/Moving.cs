using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private bool _facingRight = true;
    private int _facingWall = 1;
    private Vector2 _input = Vector2.zero;

    public Animator animator;

    // Update is called once per frame
    private void FixedUpdate()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), 0); 
        if (_input == Vector2.zero)
        {
            animator.SetBool("Walking", false);
        }
        else animator.SetBool("Walking", true);

        if ((_input.x > 0 && !_facingRight) || (_input.x < 0 && _facingRight))
        {
            Flip();
        }

        transform.Translate(speed * _input * Time.deltaTime * _facingWall);
    }

    public void LeftButton()
    {
        _input = Vector2.left;
    }

    public void RightButton()
    {
        _input = Vector2.right;
    }

    public void InputNull()
    {
        _input = Vector2.zero;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale *= new Vector2(-1, 1);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            _facingWall = 0;
        }
        else _facingWall = 1;
    }
}
