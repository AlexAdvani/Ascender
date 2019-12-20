using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float fSpeed = 5f;
	private string sDirection;

	// Use this for initialization
	void Start () 
	{
		sDirection = PlayerMovement.sDirection;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		HandleMovement ();
	}

	void HandleMovement()
	{
		Vector3 velocity = Vector3.zero;
	

		if (sDirection == "Left")
		{
			velocity.x = fSpeed * -1;
		}
		else if (sDirection == "Right")
		{
			velocity.x = fSpeed;
		}
		
		transform.position += velocity * Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Collision");

		if (other.gameObject.tag == "Ground")
		{
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}

	}
}
