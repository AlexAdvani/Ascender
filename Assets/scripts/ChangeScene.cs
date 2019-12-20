using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string sceneToChangeTo = "space";

	void OnTriggerEnter2D(Collider2D other)
	{
		print("on trigger enter 2d activate");

		if (other.tag == "Player")
		{
			print("on trigger detected player");

			if( sceneToChangeTo!= "space" )
			{
				Application.LoadLevel(sceneToChangeTo);
			}
			else
			{
				print("trigger sceneToChangeTo is not set to something other than space");
			}
		}
	}
}
