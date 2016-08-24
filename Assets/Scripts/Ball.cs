using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddleObject;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddleObject = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddleObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		//if hasStarted is not true...
		if (!hasStarted) {	
			// Lock the ball relative to the paddle
			this.transform.position = paddleObject.transform.position + paddleToBallVector;
		
		}
		//Wait for a mouse press to launch
		if (Input.GetMouseButtonDown(0) && !hasStarted) {

			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-3f, 3f), 9f);
			hasStarted = true;
		}	

	}
	
	void LateUpdate () {
		if (!Bricks.powerUpOn) {
			if (this.GetComponent<Rigidbody2D>().velocity != (9f * GetComponent<Rigidbody2D>().velocity.normalized)) {
				this.GetComponent<Rigidbody2D>().velocity = (9f * GetComponent<Rigidbody2D>().velocity.normalized); 
				Debug.Log ("Correcting velocity");
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {

		if (hasStarted) {
			GetComponent<AudioSource>().Play ();
		}
	}
}
