using UnityEngine;
using System.Collections;

public class scriptShield : MonoBehaviour 
{
	public int shieldStrength = 3;
	
	void OnTriggerEnter (Collider other) 
	{
		if(other.tag == "astroid")
		{
			shieldStrength--;
		}
	}
	
	void Update()
	{
		if(shieldStrength <= 0)
		{
			Destroy(gameObject);
		}
	}
}
