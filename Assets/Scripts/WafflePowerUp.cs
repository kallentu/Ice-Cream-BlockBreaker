using UnityEngine;
using System.Collections;

public class WafflePowerUp : MonoBehaviour {
	private Paddle paddleScript;
	private WaffleCone waffleCone;
	
	public Sprite[] whichPower;
	public AudioClip power;
	
	void Start () {
		paddleScript = GameObject.FindObjectOfType<Paddle>();
		waffleCone = GameObject.FindObjectOfType<WaffleCone>();
		
	}
	
	
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -4f);
	}
	
	void OnTriggerEnter2D (Collider2D paddleTrigger) {
		AudioSource.PlayClipAtPoint (power, transform.position, 0.3f);
		Destroy (gameObject);
		paddleScript.WaffleChange();
		waffleCone.SetUp2();
	}
}
