using UnityEngine;
using System.Collections;

public class scriptAstroid : MonoBehaviour {
	public float astroidSpeed = 6.0f;
	public Transform explosion;
	public GameObject sceneManager;
	public AudioClip shieldExplosion;
	public AudioClip playerExplosion;
	
	void Update () 
	{
		MoveAstroid();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent<scriptPlayer>().lives -= 1;
			sceneManager.transform.GetComponent<scriptSceneManager>().SubtractLife();
			audio.clip = playerExplosion;
			audio.Play();
			ExplodeAstroid();
			
			ResetAstroid();
		}
		
		if(other.gameObject.tag == "shield")
		{
			audio.clip = shieldExplosion;
			audio.Play();
			ExplodeAstroid();
			ResetAstroid();
		}
	}
	
	void ExplodeAstroid()
	{
		if(explosion)
		{
			Transform boom = (Transform)Instantiate(explosion, transform.position, transform.rotation);
			Destroy(boom.gameObject, boom.particleSystem.startLifetime + boom.particleSystem.duration);
		}
	}
	
	void MoveAstroid()
	{
		transform.Translate(Vector3.down * astroidSpeed * Time.deltaTime);
		
		if(transform.position.y <= -6)
		{
			ResetAstroid();
		}
	}
	
	public void ResetAstroid()
	{
		Vector3 position = transform.position;
		
		position.y = 8;
		position.x = Random.Range(-7.0f, 7.0f);
		
		transform.position = position;
	}
}
