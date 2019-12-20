using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
	
	// Loads Main Menu Background
	public Texture2D MainMenuBackground;

	// Loads Play Game Button
	public Texture2D PlayButtonMenu;

	// Loads Credits Button
	public Texture2D CreditsButton;

	// Loads Credits Button
	public Texture2D ExitButton;


	// Runs the button GUI
	void OnGUI()
	{
		//---------------------- Creates background for Main Menu
		Rect backGroundRect = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (backGroundRect, MainMenuBackground);


		//---------------------- Creates button for Game Play
		Rect playButtonRect = new Rect (Screen.width * 0.45f, Screen.height * 0.25f, 100, 50);
		GUI.DrawTexture (playButtonRect, PlayButtonMenu);

		// Event for Game Play
		Event e = Event.current;
		if (playButtonRect.Contains(Event.current.mousePosition) && e.type == EventType.MouseUp)
		{
			Application.LoadLevel("SecondGameScene");
			print("Button Play Pressed");
		}




		//---------------------- Creates button for Exit Game
		Rect ExitButtonRect = new Rect (Screen.width * 0.45f, Screen.height * 0.35f, 100, 50);
		GUI.DrawTexture (ExitButtonRect, ExitButton);

		// Event for Exit Game
		if (ExitButtonRect.Contains(Event.current.mousePosition) && e.type == EventType.MouseUp)
		{
			Application.Quit();
			print("Button Exit Pressed");
		}




		//---------------------- Creates button for Credits
		Rect CreditsButtonRect = new Rect (Screen.width * 0.45f, Screen.height * 0.45f, 100, 50);
		GUI.DrawTexture (CreditsButtonRect, CreditsButton);
		
		// Event for Credits
		if (CreditsButtonRect.Contains(Event.current.mousePosition) && e.type == EventType.MouseUp)
		{
			Application.LoadLevel("CreditsScene");
			print("Button Credits Pressed");
		}

		print ("Ran Menu");
	}
}
