using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AnimationControl();
		movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;
		
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded)
			Jump();
	}

    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void Jump()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		jumpPressed = false;
	}


	private void AnimationControl()
	{
		if(rigid.velocity.y == 0 && rigid.velocity.x ==0)
		{
			animator.Play("PlayerIdle");
		}
		if(rigid.velocity.y != 0 || rigid.velocity.x !=0 && !jumpPressed)
		{
			animator.Play("RunAnimate");
		}
	}
}