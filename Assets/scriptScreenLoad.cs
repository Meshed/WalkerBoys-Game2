using UnityEngine;
using System.Collections;

public class scriptScreenLoad : MonoBehaviour {
	public float waitTime = 3.0f;
	
	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			Application.LoadLevel("Level_01");
		}
		else
		{
			StartCoroutine(WaitTime());
		}
	}
	
	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
		
		GUI.Box(new Rect(0, 0, 200, 200), "Instructions");
		GUI.Label(new Rect(10, 30, 140, 40), "Arrow Keys to Move");
		GUI.Label(new Rect(10, 60, 160, 70), "Spacebar to Shoot");
		GUI.Label(new Rect(10, 90, 160, 100), "Esc to Quit the Game");
		
		GUI.EndGroup();
	}
	
	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel("Level_01");
	}
}
