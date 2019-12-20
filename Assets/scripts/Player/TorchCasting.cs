using UnityEngine;
using System.Collections;

public class TorchCasting : MonoBehaviour 
{
	int iLightDepth = 5;
	public float fLightDistance = 4f;

	bool bMouseControl = true;

	GameObject oPlayerObject;

	// Use this for initialization
	void Start () {
		oPlayerObject = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = oPlayerObject.transform.position;

		if (Input.GetKeyDown(KeyCode.Comma))
		{
			bMouseControl = !bMouseControl;
		}

		if (bMouseControl)
		{
			RotateToMouse ();	
		}
		else
		{
			RotateToStick ();
		}
	}

	void RotateToMouse()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = transform.position.z;

		Vector3 mousePositionInWorld;

		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

		mousePositionInWorld = new Vector3(mousePosition.x - transform.position.x,
		                                   mousePosition.y - transform.position.y,
		                                   iLightDepth);

		transform.rotation = Quaternion.LookRotation (mousePositionInWorld);
	}

	void RotateToStick()
	{
		float horInput = (float)Input.GetAxis ("AimHorizontal");
		float verInput = (float)Input.GetAxis ("AimVertical");

		float stickDistance = Mathf.Sqrt(Mathf.Pow (horInput, 2) + Mathf.Pow (verInput, 2));

		if (stickDistance != 0)
		{
			Vector3 lightTargetPosition = Vector3.zero;

			lightTargetPosition.x = horInput * fLightDistance;
			lightTargetPosition.y = verInput * fLightDistance;
			lightTargetPosition.z = iLightDepth;

			transform.rotation = Quaternion.LookRotation(lightTargetPosition);
		}
	}
}
/*
The function to raycast:
	Physics.Raycast(Vector3 origin, Vector3 direction, RaycastHit hitInfo, optionals[ float distance, int layerMask ]);
	
	origin = where the raycast starts from
	direction = where the raycast moves to
		these can be simplified to:
			Ray myRay = new Ray(Vector3 origin, Vector3 direction);

	hitInfo = must be given a RayCastHit <variable> to then give the info on the cast to that, which can then be used in code later
		eg if(hit.collider.tag == "environment")

	distance = sets how long the ray is
		 so say a shotgun has a short ray, but a rifle has a long ray
	layerMask = which layer to check objects in

debug option to draw a ray:
	Debug.DrawRay(Vector3 startPoint, Vector3 endPoint)
		Can be used to draw a ray, using the same variables to check stuff
*/