using UnityEngine;
using System.Collections;

public class KillTriggerScript : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other)
	{
		print("on trigger enter 2d activate");
		
		if (other.tag == "Player")
		{
			print("on trigger detected player");
			PlayerMovement.bIsAlive = false;
			PlayerMovement.iLives--;

			return;
		}
		else if (other.tag == "Enemy")
		{
			print("on trigger detected enemy");
			Destroy(other.gameObject);
			
		}
	}
}
