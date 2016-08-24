using UnityEngine;
using System.Collections;

public class KitKatPowerUp : MonoBehaviour {
	private Paddle paddleScript;
	private KitKatPaddle kitKat;
	
	public Sprite[] whichPower;
	public AudioClip power;
	
	void Start () {
		paddleScript = GameObject.FindObjectOfType<Paddle>();
		kitKat = GameObject.FindObjectOfType<KitKatPaddle>();
	}


	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -4f);
	}
	
	void OnTriggerEnter2D (Collider2D paddleTrigger) {
		AudioSource.PlayClipAtPoint (power, transform.position, 0.3f);
		Destroy (gameObject);
		paddleScript.PaddleChange();
		kitKat.SetUp2();
	}
}
