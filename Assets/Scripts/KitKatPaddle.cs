using UnityEngine;
using System.Collections;

public class KitKatPaddle : MonoBehaviour {
	
	public Sprite[] paddleType;
	public static bool paddlePower = false;

	
	// Update is called once per frame
	void Update () {
		
		if (paddlePower) 
		{
			MoveWithMouseLarger();
			
		}
		
	}

	
	void MoveWithMouseLarger () {	
		
		//Gets mouse position for X position with input.mouseposition and divided it by screen width
		//to make sure it is constant. then divided by 16 to adjust it to world units
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		
		//Setting the paddle position by creating a new vector with a clamp on the X axis, and using the
		//Y transform position already used and setting Z position to be 0
		//f is needed to be a float
		Vector3 paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, 1.5f, 14.5f), this.transform.position.y, 0f);
		
		//changes the position of the paddle with the vector above (with using mouse position)
		this.transform.position = paddlePos;
		
		
	}
	
	public void SetUp2() {
		paddlePower = true;
		Destroy (gameObject);
		WaffleCone.wafflePower = false;
	}
	

}
