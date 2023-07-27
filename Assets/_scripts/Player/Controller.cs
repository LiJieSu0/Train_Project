using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    float horizontalInput;
    float verticalInput;
    private Rigidbody2D rb;
    private bool isFliping = false;
    Animator animator;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();
        AnimationControl();
    }

    private void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        FlipSprite();
    }

    private void FlipSprite()
    {
        Vector2 scale=transform.localScale;
        if (isFliping)
        {
            if (horizontalInput > 0)
            {
                scale.x *= -1;
                isFliping= false;
            }
        }
        else
        {
            if(horizontalInput< 0)
            {
                scale.x *= -1;
                isFliping= true;
            }
        }
        transform.localScale = scale;
    }

    private void AnimationControl()
    {
        if (horizontalInput != 0) animator.SetBool("isMoving", true);
        else { animator.SetBool("isMoving", false); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            Debug.Log("Gameover");
        }
    }
}
