using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Rigidbody2D missileObject;
	public float rocketLaunchHSpeed = 20f;
	public float rocketLaunchVSpeed = 5f;
	public float timeBetweenShoot = 2.0f;
	float timeBetweenShootStore = 1.0f;

	private Animator animObject;

	private Transform playerPos;
		Vector3 playerPosition = new Vector3 (0.0f, 0.0f, 0.0f);

	public float rangeDetectZoneRadius = 6.0f;




	// Use this for initialization
	void Start () 
	{
		timeBetweenShootStore = timeBetweenShoot;
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
		//animObject = this.GetComponent<Animator> ();	
	}




	// Update is called once per frame
	void FixedUpdate () 
	{
		vGetPlayerPosition();

		if (bCheckIfPlayerIsInRange() == true)
		{
			if(timeBetweenShoot > timeBetweenShootStore)
			{
				vShootAtEnemy();
			}
			else
			{
				timeBetweenShoot += 0.2f;
			}
		}	
	}


	void vGetPlayerPosition () 
	{
		playerPosition = playerPos.transform.position;
	}
	
	bool bCheckIfPlayerIsInRange () 
	{
		if ( Physics2D.OverlapCircle(transform.position, rangeDetectZoneRadius, 1 << LayerMask.NameToLayer("Player")) == true) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void vShootAtEnemy () 
	{
		//animObject.SetTrigger ("shootGun");

		Rigidbody2D bulletInstance = Instantiate(missileObject, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(rocketLaunchHSpeed, rocketLaunchVSpeed);

		timeBetweenShoot = 0.0f - (Random.Range(0.5f, 2.0f));
	}
}
