using UnityEngine;
using System.Collections;

public class EnemyRocket : MonoBehaviour {

	// Prefab of explosion effect.
	public GameObject explosion;
	public float timeTillAutoDestruct = 3f;

	void Start () 
	{
		//destroy missile after 3 seconds if it hasnt collided with anything
		Destroy(gameObject, timeTillAutoDestruct);
	}

	void FixedUpdate () 
	{
	
	}

	void explode()
	{
		// Create a quaternion with a random rotation in the z-axis
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation
		Instantiate(explosion, transform.position, randomRotation);
	}

	//using the trigger that is activeted when the rocket collides with anything
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits the player
		if(col.tag == "Player")
		{
			print ("an enemy rocket has collided with a player object");
			//get the player script to kill the player
			//col.gameObject.GetComponent<Enemy>().Hurt();
			
			// Call the explosion instantiation
			explode();
			
			// Destroy the rocket
			Destroy (gameObject);
		}
		// If it hits another enemy
		else if(col.tag == "Enemy")
		{
			print ("an enemy rocket has collided with an enemy");
			// Instantiate the explosion and destroy the rocket
			//explode();
			//Destroy (gameObject);
		}
		else
		{
			print ("an enemy rocket has collided with something");
		}
	}

}