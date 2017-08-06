using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
	Rigidbody2D rb;
	public float speed, jumpPower;
	float x;
	bool isRunning;
	public bool isGrounded, isJumping;

	public Slider kSlider;


	void Start ()
	{
		isJumping = false;
		isGrounded = true;
		rb = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.Space)) && !isJumping) 
		{	
			isJumping = true;
			isGrounded = false;
			rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
		}

		x = Input.GetAxis ("Horizontal");
		Vector3 move = new Vector3 (x * speed, rb.velocity.y, 0f);
		rb.velocity = move;


	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "book")
		{
			Debug.Log (other.gameObject.GetComponentInChildren(typeof(Transform)).name);
			Destroy (other.gameObject);
			UpdateSlider ();
		}

		if(other.gameObject.tag == "ground")
		{
			isGrounded = true;
			isJumping = false;
		}

		if(other.gameObject.tag == "capsule")
		{
			Debug.Log ("Changing the color of the game");
			Destroy (other.gameObject);
		}


	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "ground")
		{
			isGrounded = false;
		}
	}

	void UpdateSlider()
	{
		if (kSlider.value <= 10) 
		{
			kSlider.value++;
		}
	}

}
