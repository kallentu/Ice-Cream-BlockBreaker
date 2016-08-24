using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {
	
	private Ball ballVelo;
	private static int catchPower;
	
	public Sprite[] bears;
	public AudioClip power;
	
	void Start () {
		ballVelo = GameObject.FindObjectOfType<Ball>();

		//Randomizes which bear to pick, 2 is exclusive so it's two sprites
		catchPower = Random.Range(0, 2);
		
		//Makes sure there is always a sprite on the bear
		if (bears[catchPower] != null) {
			this.GetComponent<SpriteRenderer>().sprite = bears[catchPower];
		}
		else {
			Debug.LogError ("Bear Sprite missing.");
		}
		
	}
	
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -4f);
		
	
		if (catchPower == 0 && Bricks.powerUpOn) {
			if (ballVelo.GetComponent<Rigidbody2D>().velocity != (4f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized)) {
				ballVelo.GetComponent<Rigidbody2D>().velocity = (4f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized); 
				Debug.Log ("Slower velocity!");
			}
		}
		else if (catchPower == 1 && Bricks.powerUpOn) {
			if (ballVelo.GetComponent<Rigidbody2D>().velocity != (13f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized)) {
				ballVelo.GetComponent<Rigidbody2D>().velocity = (13f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized); 
				Debug.Log ("Faster velocity!");
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D paddleTrigger) {
		AudioSource.PlayClipAtPoint (power, transform.position, 0.3f);
		Bricks.powerUpOn = true;
		Destroy (gameObject);
	}
}
