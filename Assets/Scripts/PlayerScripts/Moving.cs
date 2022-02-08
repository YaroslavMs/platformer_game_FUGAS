using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private bool _facingRight = true;
    private Vector2 _input = Vector2.zero;

    public Animator animator;
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

        transform.Translate(speed * _input * Time.deltaTime);
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
    
}
