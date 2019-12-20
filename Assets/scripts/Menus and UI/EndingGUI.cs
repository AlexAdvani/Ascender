using UnityEngine;
using System.Collections;

public class EndingGUI : MonoBehaviour {

	// Loads Credits Background
	public Texture2D endingImage;

	// Load Back to Main Menu button
	public Texture2D ButtonExit;
	
	void OnGUI()
	{
		// Creates background for Credits
		Rect EndingbackGroundRect = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (EndingbackGroundRect, endingImage);


		// Creates button for instructions
		Rect rect = new Rect (Screen.width * 0.15f, Screen.height * 0.6f, 100, 50);
		GUI.DrawTexture (rect, ButtonExit);
		
		// Event for instructions
		Event e = Event.current;
		if (rect.Contains(Event.current.mousePosition) && e.type == EventType.MouseUp)
		{
			Application.LoadLevel("CreditsScene");
			print("Button Back To Menu Pressed");
		}
	}
}
