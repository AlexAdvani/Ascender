using UnityEngine;
using System.Collections;

public class GameEscapeScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//firstly check if the player is dead, then check for keypresses
		if (PlayerMovement.iLives <= 0)
		{
			PlayerMovement.iLives = 3;
			Application.LoadLevel("MainMenuScene");
		}
		// Escape button pressed
		else if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenuScene");
			print("Escape Script Pressed");
		}
		//-----------------------------Cheat to level buttons
		else if (Input.GetKey(KeyCode.J))
		{
			Application.LoadLevel("SecondGameScene");
			print("move to castle scene button Pressed");
		}
		else if (Input.GetKey(KeyCode.K))
		{
			Application.LoadLevel("ThirdGameScene");
			print("move to cave scene button Pressed");
		}
		else if (Input.GetKey(KeyCode.L))
		{
			Application.LoadLevel("FinalGameScene");
			print("move to ice scene button Pressed");
		}
		//-----------------------------Cheat to ending button
		else if (Input.GetKey(KeyCode.M))
		{
			Application.LoadLevel("EndingScene");
			print("move to ice scene button Pressed");
		}
	}
}
