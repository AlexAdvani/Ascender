using UnityEngine;
using System.Collections;

public class EnemyRemoveScript : MonoBehaviour {

	// Whether or not this gameobject should destroyed after a delay, on Awake.
	public bool destroyOnAwake;	
	// The delay for destroying it on Awake
	public float awakeDestroyDelay;	
	// Find a child game object and delete it
	public bool findChild = false;	
	// Name the child object in the component view
	public string namedChild;			
	
	//if the thing needs to delete self upon awake
	void Awake ()
	{
		if(destroyOnAwake)
		{
			if(findChild)
			{
				Destroy (transform.Find(namedChild).gameObject);
			}
			else
			{
				Destroy(gameObject, awakeDestroyDelay);
			}
			
		}
		
	}
	
	void DestroyChildGameObject ()
	{
		if(transform.Find(namedChild).gameObject != null)
			Destroy (transform.Find(namedChild).gameObject);
	}
	
	void DisableChildGameObject ()
	{
		if(transform.Find(namedChild).gameObject.activeSelf == true)
			transform.Find(namedChild).gameObject.SetActive(false);
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}
