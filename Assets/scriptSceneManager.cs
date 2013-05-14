using UnityEngine;
using System.Collections;

public class scriptSceneManager : MonoBehaviour {
	public float gameTime = 60.0f;
	public static int score = 0;
	public static int lives = 3;
	
	void Start()
	{
		InvokeRepeating("CountDown", 1.0f, 1.0f);
	}
	
	void Update () 
	{
		bool gameOver = false;
		
		if(lives <= 0)
		{
			PlayerPrefs.SetInt("score", score);
			Application.LoadLevel("ScreenLose");
			gameOver = true;
		}
		
		if(gameTime <= 0)
		{
			PlayerPrefs.SetInt("score", score);
			Application.LoadLevel("ScreenWin");
			gameOver = true;
		}
		
		if(gameOver)
		{
			lives = 3;
			score = 0;
		}
	}
	
	public void AddScore()
	{
		score++;
	}
	
	public void SubtractLife()
	{
		lives--;
	}
	
	void CountDown()
	{
		if(--gameTime == 0)
		{
			CancelInvoke("CountDown");
		}
	}
	
	public void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
		GUI.Label(new Rect(10, 25, 100, 35), "Lives: " + lives);
		GUI.Label(new Rect(Screen.width - 75, 10, 100, 20), "Counter: " + gameTime);
	}
}
