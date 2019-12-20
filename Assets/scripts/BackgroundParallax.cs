using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

	public float fSpeed = 1.0f;
	public bool bFollowCamera = true;
	
	//private Transform player;
	public Transform mainCameraPos;
	private CameraScroll cameraScrollScript;
	
	void Start()
	{
		cameraScrollScript = Camera.main.GetComponent<CameraScroll> ();
	}

	void FixedUpdate ()
	{
		Vector3 tempVariable = transform.position;

		var cameraMainX = Camera.main.transform.position.x;
		var cameraMainY = Camera.main.transform.position.y;

		if (bFollowCamera == true) 
		{
			tempVariable.x += cameraScrollScript.v2CameraTranslation.x * fSpeed * Time.deltaTime;
			tempVariable.y += cameraScrollScript.v2CameraTranslation.y * fSpeed * Time.deltaTime;
			transform.position = tempVariable;
		}
		else 
		{
			tempVariable.x = -mainCameraPos.position.x * fSpeed;
			tempVariable.y = -mainCameraPos.position.y * fSpeed;
			transform.position = tempVariable;
		}

	}
}