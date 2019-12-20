using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour
{
	public GUITexture[] livesArray;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < livesArray.Length; i++)
		{
			if (i > PlayerMovement.iLives - 1)
			{
				livesArray[i].gameObject.SetActive(false);
			}
			else
			{
				livesArray[i].gameObject.SetActive(true);
			}
		}
	}
}