using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuloPlayer : MonoBehaviour
{

	public float jumpSpeed = 3f;
	public float jumpDelay = 2f;

	private bool canjump;
	private bool isjumping;
	private Rigidbody rb;
	private float countDown;

	
	void Start()
	{
		canjump = true;
		rb = GetComponent<Rigidbody>();
		countDown = jumpDelay;
	}

	
	void Update()
	{
		if (isjumping && countDown > 0)
			countDown -= Time.deltaTime;
		else
		{
			canjump = true;
			isjumping = false;
			countDown = jumpDelay;
		}

	}

	public void StartLetsJump()
	{
		if (canjump)
		{
			canjump = false;
			isjumping = true;
			rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
		}

		Debug.Log("Pulou");
	}

	

}