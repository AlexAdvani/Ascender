using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour 
{
	public Transform tTrackObject;
	
	public Vector2 v2DeadZoneSize;
	public float fTrackingSpeed = 4f;

	public Vector2 v2CameraTranslation;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		v2CameraTranslation = Vector2.zero;
		Vector3 trackingPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		if (Mathf.Abs(transform.position.x - tTrackObject.position.x) > v2DeadZoneSize.x)
		{
			trackingPosition.x = Mathf.Lerp (transform.position.x, tTrackObject.position.x, fTrackingSpeed * Time.deltaTime);
			v2CameraTranslation.x = transform.position.x - trackingPosition.x;
		}

		if (Mathf.Abs(transform.position.y - tTrackObject.position.y) > v2DeadZoneSize.y)
		{
			trackingPosition.y = Mathf.Lerp (transform.position.y, tTrackObject.position.y, fTrackingSpeed * Time.deltaTime);
			v2CameraTranslation.y = transform.position.y - trackingPosition.y;
		}

		transform.position = trackingPosition;
	}
}
