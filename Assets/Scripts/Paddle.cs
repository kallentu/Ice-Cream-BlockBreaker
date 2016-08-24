using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private KitKatPaddle messageKitKat;
	private WaffleCone messageWaffle;
	private Ball ballPosition;
	
	// Use this for initialization
	void Start () {
		ballPosition = GameObject.FindObjectOfType<Ball>();
		messageKitKat = GameObject.FindObjectOfType<KitKatPaddle>();
		messageWaffle = GameObject.FindObjectOfType<WaffleCone>();
 
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
	}
	
	public void PaddleChange () {
		if (messageKitKat != null)
		{
			Instantiate (messageKitKat, this.transform.position, this.transform.rotation);
			Destroy (gameObject);
		}


	}
	
	public void WaffleChange () {
		if (messageWaffle != null)
		{
			Instantiate (messageWaffle, this.transform.position, this.transform.rotation);
			Destroy (gameObject);
		}
		
	}
	
	void AutoPlay() {
		//Gets mouse position for X position with input.mouseposition and divided it by screen width
		//to make sure it is constant. then divided by 16 to adjust it to world units
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		
		Vector3 ballPos = ballPosition.transform.position;
		
		//Setting the paddle position by creating a new vector with a clamp on the X axis, and using the
		//Y transform position already used and setting Z position to be 0
		//f is needed to be a float
		Vector3 paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);
		
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		//changes the position of the paddle with the vector above (with using mouse position)
		this.transform.position = paddlePos;
	
	}
	
	void MoveWithMouse () {
		//Gets mouse position for X position with input.mouseposition and divided it by screen width
		//to make sure it is constant. then divided by 16 to adjust it to world units
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		
		//Setting the paddle position by creating a new vector with a clamp on the X axis, and using the
		//Y transform position already used and setting Z position to be 0
		//f is needed to be a float
		Vector3 paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);
		
		//changes the position of the paddle with the vector above (with using mouse position)
		this.transform.position = paddlePos;
	
	
	}
}
