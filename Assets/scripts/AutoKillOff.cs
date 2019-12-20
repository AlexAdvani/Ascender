using UnityEngine;
using System.Collections;

public class AutoKillOff : MonoBehaviour {

	public float timeTillAutoDestruct = 1.0f;

	// Use this for initialization
	void Start () {
		//destroy this gameObject after a set period
		Destroy(gameObject, timeTillAutoDestruct);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
