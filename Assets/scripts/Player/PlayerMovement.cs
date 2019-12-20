using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private Animator animator;

	private Vector3 v3Velocity = Vector3.zero;
	private Vector3 v3FlipScale = new Vector3(1, 1, 1);

	public static string sDirection = "Right";

	public float fMoveSpeed = 1.0f;
	public float fMaxMoveSpeed = 5.0f;

	public float fFriction = 1.0f;
	private bool bIsSkidding = false;

	private bool bLeftRunButton = false;
	private bool bRightRunButton = false;

	private bool bHasJumped = false;
	private bool bIsGrounded = true;

	public float fJumpHeight = 5f;
	public float fJumpDelay = 0.25f;
	private float fJumpTimer = 0f;
	
	private bool bLandedOnGround = false;

	public static bool bIsAlive = true;

	public float fReviveTime = 2f;
	private float fReviveTimer = 0;

	public LayerMask groundMask;
	public Transform tGroundCollisionPoint;
	public float fGroundDetectionRadius = 0.1f;

	private float fHorAxis;

	public static int iLives = 3;

	private Vector3 v3RespawnPosition;


	// Use this for initialization
	void Start () 
	{	
		animator = this.GetComponent<Animator> ();

		v3RespawnPosition = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		fHorAxis = Input.GetAxis("Horizontal");

		if (bIsAlive)
		{
			HandleHorizontalMovement ();
			HandleJump ();
		}

		CheckGroundCollision ();

		HandleAnimationParameters ();
		RevivePlayer ();

		transform.localScale = v3FlipScale;

		//detect keys
		//morphing?
	} 

	void FixedUpdate()
	{
		rigidbody2D.AddForce (v3Velocity);
	}

	void HandleHorizontalMovement()
	{		
		//Detect Keys
		v3Velocity.x = fHorAxis * fMoveSpeed;
		
		if (fHorAxis > 0) 
		{
			bLeftRunButton = false;
			bRightRunButton = true;

			bIsSkidding = false;

			sDirection = "Right";
		}
		else if (fHorAxis < 0)
		{
			bLeftRunButton = true;
			bRightRunButton = false;

			bIsSkidding = false;
			
			sDirection = "Left";
		}
		else 
		{
			bLeftRunButton = false;
			bRightRunButton = false;

			Vector3 frictionForce = Vector3.zero;

			if (rigidbody2D.velocity.x > 0)
			{
				frictionForce.x = -fFriction;
				bIsSkidding = true;
			}
			else if (rigidbody2D.velocity.x < 0)
			{
				frictionForce.x = fFriction;
				bIsSkidding = true;
			}
			else
			{
				bIsSkidding = false;
			}

			rigidbody2D.AddForce(frictionForce);
		}

		if (rigidbody2D.velocity.x > fMaxMoveSpeed) 
		{
			rigidbody2D.velocity = new Vector2(fMaxMoveSpeed, rigidbody2D.velocity.y);
		}
		else if (rigidbody2D.velocity.x < -fMaxMoveSpeed) 
		{
			rigidbody2D.velocity = new Vector2(-fMaxMoveSpeed, rigidbody2D.velocity.y);
		}
	}

	void HandleJump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			if (!bHasJumped && bIsGrounded)
			{
				bHasJumped = true;
				fJumpTimer = 0f;
			}
		}

		if (bHasJumped && bIsGrounded)
		{
			fJumpTimer += Time.deltaTime;

			if (fJumpTimer >= fJumpDelay) 
			{
				rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, fJumpHeight));
				bIsGrounded = false;
			}
		}
	}

	void HandleAnimationParameters()
	{
		if (sDirection == "Left") 
		{
			v3FlipScale.x = -1;
		}
		else if (sDirection == "Right") 
		{
			v3FlipScale.x = 1;
		}

		if (Input.GetKeyDown (KeyCode.P)) 
		{
			if (bIsAlive)
			{
				bIsAlive = false;
				iLives--;
			}
		}

		animator.SetFloat ("fHorizontalSpeed", fHorAxis);
		animator.SetFloat ("fVerticalSpeed", rigidbody2D.velocity.y);
		
		animator.SetBool ("bLeftRunButton", bLeftRunButton);
		animator.SetBool ("bRightRunButton", bRightRunButton);

		animator.SetBool ("bIsSkidding", bIsSkidding);
		
		animator.SetBool ("bJumpButton", bHasJumped);
		animator.SetBool ("bOnGround", bIsGrounded);
		animator.SetBool ("bGroundCollision", bLandedOnGround);

		animator.SetBool ("bIsAlive", bIsAlive);
	}

	void CheckGroundCollision()
	{
		Vector2 collisionPoint = new Vector2 (tGroundCollisionPoint.position.x, tGroundCollisionPoint.position.y);

		if (Physics2D.OverlapCircle (collisionPoint, fGroundDetectionRadius, groundMask))
		{
			if (!bIsGrounded)
			{
				bHasJumped = false;
				bIsGrounded = true;

				bLandedOnGround = true;	
			}
		}
		else
		{
			bIsGrounded = false;
			bLandedOnGround = false;
		}
	}

	void RevivePlayer()
	{
		if (!bIsAlive)
		{
			fReviveTimer += Time.deltaTime;

			if (fReviveTimer >= fReviveTime)
			{
				fReviveTimer = 0;

				transform.position = v3RespawnPosition;

				bIsAlive = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyBullet")
		{
			if (bIsAlive)
			{
				iLives--;
				bIsAlive = false;
			}
		}
	}
}
