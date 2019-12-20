using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public string sMovementType = "platforming";
		//movements supported
			//floating
			//platforming
			//jumping
	public float fHorMoveSpeed = 2.5f;
	public float fVerMoveSpeed = 2.5f;

	public float fDetectZoneRadius = 5f;	

	bool hasJumped = false;
	bool onGround = false;

	private Transform playerPos;
	private Animator animLink;

	// Use this for initialization
	void Start () {

		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		animLink = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		animLink.SetFloat("moveSpeed", rigidbody2D.velocity.x);

		//if the player enters the detect zone
		if(  Physics2D.OverlapCircle(transform.position, fDetectZoneRadius, 1 << LayerMask.NameToLayer("Player"))  )
		{
			print("player entering an enemy detect zone");
			vHorMovement ( );
			vVerMovement ( sMovementType );
		}
	}

	//---------------------------------------------------------

	void vHorMovement()
	{
		//if player is to the left - x value is less than enemy's
		if (playerPos.position.x < transform.position.x)
		{
			//move to the right
			rigidbody2D.velocity = new Vector2(transform.localScale.x * fHorMoveSpeed, rigidbody2D.velocity.y);	
		}
		//else if player is to the right - x value is greater than enemy's
		else if (playerPos.position.x > transform.position.x)
		{
			//move to the left
			rigidbody2D.velocity = new Vector2(transform.localScale.x * -fHorMoveSpeed, rigidbody2D.velocity.y);	
		}
	}



	//---------------------------------------------------------

	void vVerMovement(string movement)
	{/*
		//---------------------------------------------------
		if(movement == "floating")
		{
			var velTemp = rigidbody2D.velocity.y;

			var posX = transform.position.x - playerPos.transform.position.x;
			var posY = transform.position.y - playerPos.transform.position.x;

			var movementAngle = Mathf.Atan(posY/posX);

			velTemp = Mathf.Sin(movementAngle);

			Vector3 vectTemp = new Vector3(transform.position.x,velTemp,transform.position.z);

			transform.Translate(vectTemp);
		}
		//---------------------------------------------------
		else if (movement == "platforming")
		{
			if (hasJumped == false && onGround == true)
			{				
				if (playerPos.position.y > transform.position.y)
				{
					print("vertical movement triggering");

					//move to the left
					rigidbody2D.velocity = new Vector2(transform.localScale.x, rigidbody2D.velocity.y * fVerMoveSpeed);	
				}

				hasJumped = true;
			}
		}
		//---------------------------------------------------
		else if (movement == "jumping")
		{
			if (hasJumped == false && onGround == true)
			{				
				if (playerPos.position.y > transform.position.y)
				{
					print("vertical movement triggering");
					
					//move to the left
					rigidbody2D.velocity = new Vector2(transform.localScale.x, rigidbody2D.velocity.y * fVerMoveSpeed);	
				}
				
				hasJumped = true;
			}
		}
	}

	
	void vCheckGroundCollision()
	{
		if (Physics2D.OverlapCircle (transform.position, 1f, 1 << LayerMask.NameToLayer("Ground")))
		{
			hasJumped = false;
			onGround = true;
		}
		else
		{
			onGround = false;
		}
	*/}
}
