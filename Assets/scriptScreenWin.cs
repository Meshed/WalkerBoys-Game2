using UnityEngine;
using System.Collections;

public class scriptScreenWin : MonoBehaviour {
	public string winQuote = "You Win!";
	
	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100));
		GUI.Box(new Rect(0, 0, 200, 100), winQuote);
		GUI.Label(new Rect(10, 30, 200, 50), "Score: " + PlayerPrefs.GetInt("score"));
		
		if(GUI.Button(new Rect(60, 60, 80, 30), "Main Menu"))
		{
			Application.LoadLevel("ScreenMainMenu");
		}
		
		GUI.EndGroup();
	}
}
