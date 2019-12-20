using UnityEngine;
using System.Collections;

public class PlayerDrone : MonoBehaviour 
{
	public Transform bulletPrefab;
	public Transform bulletFirePosition;

	public float fFireRate = 1f;
	private float fFireTimer = 0f;

	public bool bCanShoot = true;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerMovement.bIsAlive)
		{
			FireBullet ();
		}
	}

	void FireBullet()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (bCanShoot)
			{
				Instantiate(bulletPrefab, bulletFirePosition.position, Quaternion.identity);

				fFireTimer = 0;
				bCanShoot = false;
			}
		}

		if (!bCanShoot)
		{
			fFireTimer += Time.deltaTime;

			if (fFireTimer >= fFireRate)
			{
				bCanShoot = true;
			}
		}
	}
}
