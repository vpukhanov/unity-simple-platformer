﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;


	private bool grounded = false;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}

		// Check death
		if (this.transform.position.y < -10)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (jump)
		{
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

}