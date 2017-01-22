using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour {

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	public void LoadLevel(string nextLevel) {
		SceneManager.LoadScene (nextLevel);
	}
}
