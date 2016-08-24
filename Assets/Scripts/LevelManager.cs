using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public int currentLevel;
	public int lastLevel;
	public AudioClip next;

	void Start () {
		//Set currentLevel as the application's index number
		currentLevel = PlayerPrefs.GetInt("LastLevelLoaded");
		Debug.Log ("Current Level is " + currentLevel);
		AudioSource.PlayClipAtPoint (next, transform.position, 1f);

	}
	
	void Update () {
		//saves current level if it changed
		if (Application.loadedLevel != currentLevel)
		{
			if (Application.loadedLevelName != "Lose") {
				currentLevel = Application.loadedLevel;
				PlayerPrefs.SetInt("LastLevelLoaded", currentLevel);
				Debug.Log ("Setting Current level to " + currentLevel);
			}
		}
	
	
	}
	
	public void LoadLastLevel () {
	//Brings player back to last failed level (otherwise known as a save)
		Bricks.breakableCount = 0;
		Bricks.powerUpOn = false;
		KitKatPaddle.paddlePower = false;
		WaffleCone.wafflePower = false;
		Application.LoadLevel(currentLevel);
	}

	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " +name);
		Bricks.breakableCount = 0;
		Bricks.powerUpOn = false;
		KitKatPaddle.paddlePower = false;
		WaffleCone.wafflePower = false;
		Application.LoadLevel(name);
	}
	
	//takes index number which is loadedlevel and adds one to it
	public void LoadNextLevel() {
		Bricks.breakableCount = 0;
		Bricks.powerUpOn = false;
		KitKatPaddle.paddlePower = false;
		WaffleCone.wafflePower = false;
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}
	
	public void BrickDestroyed() {
		if (Bricks.breakableCount <= 0) {
			LoadNextLevel();
		}
		
	}
	
	public void QuitRequest () {
		Debug.Log ("Quit requested.");
		Application.Quit();
	}
	
	
}
