using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	public static bool powerUpOn = false;
	
	private LevelManager levelLoad;
	private KitKatPowerUp bigPaddle;
	private WafflePowerUp smallPaddle;
	private Bear bear;
	private int timesHit;
	private bool isBreakable;
	

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		
		levelLoad = GameObject.FindObjectOfType<LevelManager>();
		bigPaddle = GameObject.FindObjectOfType<KitKatPowerUp>();
		smallPaddle = GameObject.FindObjectOfType<WafflePowerUp>();
		bear = GameObject.FindObjectOfType<Bear>();
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (isBreakable && !(this.transform.parent.tag == "PowerUp") ) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.08f);
			HandleHits();
		}
		else if (isBreakable && (this.transform.parent.tag == "PowerUp") ) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.08f);
			PowerUpHandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		// length of hitsprites is just size
		int maxHits = hitSprites.Length + 1;
		// If maxHits is reached, the breakable block count will decrease and the gameobject will be destroyed
		if (timesHit >= maxHits) {
			breakableCount--;
			levelLoad.BrickDestroyed();
			SmokeEffect();
			Destroy (gameObject);
		}
		else {
			LoadSprites();
		}
	
	}
	
	void PowerUpHandleHits () {
		timesHit++;
		// length of hitsprites is just size
		int maxHits = hitSprites.Length + 1;
		// If maxHits is reached, the breakable block count will decrease and the gameobject will be destroyed
		if (timesHit >= maxHits) {
			breakableCount--;
			levelLoad.BrickDestroyed();
			SmokeEffect();
			Destroy (gameObject);
			
			//This will drop a powerup
			PowerUpEffects();
		}
		else {
			LoadSprites();
		}
	
	}
	
	void PowerUpEffects () {
		
			int randomEffect = Random.Range(1, 5);
			
			switch (randomEffect)
			{
			case 1:
				if (!KitKatPaddle.paddlePower && !WaffleCone.wafflePower) {
					//Paddle turns into chocolate bar (gets larger)
					Instantiate (bigPaddle, this.transform.position, this.transform.rotation);
				}
				break;
			case 2:
				//Velocity of ball decreases/increase
				powerUpOn = false;
				Instantiate (bear, this.transform.position, this.transform.rotation);
				break;
			case 3:
				if (!WaffleCone.wafflePower && !KitKatPaddle.paddlePower ) {
					//Paddle gets smaller

					Instantiate (smallPaddle, this.transform.position, this.transform.rotation);
				}
				break;
			case 4:
				//Velocity of ball decreases/increase
				powerUpOn = false;
				Instantiate (bear, this.transform.position, this.transform.rotation);
				break;
			default:
				Debug.Log ("No PowerUps, I guess? :/");
				break;
			}
			
	}
	
	void SmokeEffect () {
		GameObject smokepuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokepuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	
	void LoadSprites () {
	//sprite index shows which sprite in unity to load
		int spriteIndex = timesHit - 1;
		
		
	//We get a component from SpriteRenderer which is the sprite and we assign which number of sprite to load
	//which is the sprite index in the hitsprites array
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
		Debug.LogError ("Brick Sprite missing.");
		}
	}
	
	

}
