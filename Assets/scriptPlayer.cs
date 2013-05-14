using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour {
	public float playerSpeedVertical = 10.0f;
	public float playerSpeedHorizontal = 10.0f;
	public float horizontalMinimum = -6.0f;
	public float horizontalMaximum = 6.0f;
	public float verticalMinimum = -3.5f;
	public float verticalMaximum = 5.0f;
	public Transform projectile;
	public Transform socketProjectile;
	public int lives = 3;
	public int numberOfShields = 4;
	public Transform shieldMesh;
	public KeyCode shieldKeyInput;
	
	private bool shieldOn = false;
	
	void Update () 
	{
		MovePlayer();
		KeepPlayerInBounds();
		
		if(Input.GetKeyDown("space"))
		{
			Instantiate(projectile, socketProjectile.position, socketProjectile.rotation);
			audio.Play();
		}
		
		if(Input.GetKeyDown(shieldKeyInput))
		{
			if(!shieldOn)
			{
				if(shieldMesh)
				{
					Transform clone = (Transform)Instantiate(shieldMesh, transform.position, transform.rotation);
					clone.parent = gameObject.transform;
					shieldOn = true;
				}
			}
		}
	}
	
	void MovePlayer()
	{
		float transV = Input.GetAxis("Vertical") * playerSpeedVertical * Time.deltaTime;
		float transH = Input.GetAxis("Horizontal") * playerSpeedHorizontal * Time.deltaTime;
		
		transform.Translate(transH, transV, 0);
	}
	
	void KeepPlayerInBounds()
	{
		Vector3 position = transform.position;
		
		position.x = Mathf.Clamp(position.x, horizontalMinimum, horizontalMaximum);
		position.y = Mathf.Clamp(position.y, verticalMinimum, verticalMaximum);
		
		transform.position = position;
	}
}
