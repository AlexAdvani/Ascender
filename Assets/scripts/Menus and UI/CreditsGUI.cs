using UnityEngine;
using System.Collections;

public class CreditsGUI : MonoBehaviour {

	// Loads Credits Background
	public Texture2D credits_v1;

	// Load Back to Main Menu button
	public Texture2D PlayButtonMenu;
	
	void OnGUI()
	{
		// Creates background for Credits
		Rect CreditsbackGroundRect = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (CreditsbackGroundRect, credits_v1);


		// Creates button for instructions
		Rect rect = new Rect (Screen.width * 0.45f, Screen.height * 0.8f, 100, 50);
		GUI.DrawTexture (rect, PlayButtonMenu);
		
		// Event for instructions
		Event e = Event.current;
		if (rect.Contains(Event.current.mousePosition) && e.type == EventType.MouseUp)
		{
			Application.LoadLevel("MainMenuScene");
			print("Button Back To Menu Pressed");
		}
	}
}
