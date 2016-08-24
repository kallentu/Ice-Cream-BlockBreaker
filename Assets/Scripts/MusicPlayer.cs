using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer initialLoad = null;

	void Awake () {

		if (initialLoad != null)
		{
			Destroy (gameObject);
		}
		else
		{
			initialLoad = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

}
