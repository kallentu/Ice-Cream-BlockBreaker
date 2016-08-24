using UnityEngine;
using System.Collections;

public class FastBear : MonoBehaviour {

	private Ball ballVelo;
	public static bool startPower = false;
	
	void Start () {
		ballVelo = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -4f);
		
		if (Bricks.powerUpOn && startPower) {
			if (ballVelo.GetComponent<Rigidbody2D>().velocity != (13f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized)) {
				ballVelo.GetComponent<Rigidbody2D>().velocity = (13f * ballVelo.GetComponent<Rigidbody2D>().velocity.normalized); 
				Debug.Log ("Faster velocity!");
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D paddleTrigger) {
		Bricks.powerUpOn = true;
		startPower = true;
		Destroy (gameObject);
	}
}
