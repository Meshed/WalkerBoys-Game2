using UnityEngine;
using System.Collections;

public class scriptScreenCredit : MonoBehaviour {
	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 220));
		
		GUI.Box(new Rect(0, 0, 200, 220), "Credits");
		
		GUI.Label(new Rect(10, 40, 200, 50), 	"Designer		Eric Walker");
		GUI.Label(new Rect(10, 70, 200, 80), 	"Artist				Eric Walker");
		GUI.Label(new Rect(10, 100, 200, 110), 	"Software		Mark Brown");
		GUI.Label(new Rect(10, 130, 200, 140), 	"Level Design	Eric Walker");
		
		if(GUI.Button(new Rect(60, 175, 80, 30), "Back"))
		{
			Application.LoadLevel("ScreenMainMenu");
		}
		
		GUI.EndGroup();
	}
}
