using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelScript;
	
	void Start () {
		levelScript = GameObject.FindObjectOfType<LevelManager>();
	}
	
	
	void OnTriggerEnter2D (Collider2D ballTrigger) { 
		levelScript.LoadLevel("Lose");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");	

	}
	
}
