using UnityEngine;
using System.Collections;

public class scriptBullet : MonoBehaviour {
	public float bulletSpeed = 15.0f;
	public float heightLimit = 10.0f;
	public Transform explosion;
	public GameObject sceneManager;
	public AudioClip fxSound;
	
	private bool alive = true;
	
	void Update ()
	{
		MoveBullet();
		CheckBulletLife();
		if(!alive) DestroyBullet();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "astroid")
		{
			other.GetComponent<scriptAstroid>().ResetAstroid();
			
			FireExplosion();
			alive = false;
			
			sceneManager.transform.GetComponent<scriptSceneManager>().AddScore();
		}
	}
	
	void FireExplosion()
	{
		if(explosion)
		{
			Transform newExplosion = (Transform)Instantiate(explosion, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(fxSound, transform.position);
			Destroy(newExplosion.gameObject, newExplosion.particleSystem.duration + newExplosion.particleSystem.startLifetime);
		}
	}
	
	void MoveBullet()
	{
		transform.Translate(0.0f, bulletSpeed * Time.deltaTime, 0.0f);
	}
	
	void CheckBulletLife()
	{
		if(transform.position.y >= heightLimit)
		{
			alive = false;
		}
	}
	
	void DestroyBullet()
	{
		DestroyObject(gameObject);
	}
}
