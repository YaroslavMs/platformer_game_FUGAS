using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private bool _facingRight = true;
    private int _facingWall = 1;

    public Animator animator;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (input == Vector2.zero)
        {
            animator.SetBool("Walking", false);
        }
        else animator.SetBool("Walking", true);

        if ((input.x > 0 && !_facingRight) || (input.x < 0 && _facingRight))
        {
            Flip();
        }

        transform.Translate(speed * input * Time.deltaTime * _facingWall);
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
