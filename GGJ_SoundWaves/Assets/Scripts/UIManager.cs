using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public Canvas endLevelMenu;
	public Text lemmingsSavedText;
	public Text lemmingsDestroyedText;

	public Canvas inGameUI;

	public Canvas pauseMenu;

	public string nextLevel;

	// Use this for initialization
	void Start () {
		endLevelMenu.enabled = false;
	}

	public void SetEndLevel(int lemmingsSaved, int lemmingsDestroyed) {
		endLevelMenu.enabled = true;
		lemmingsSavedText.text = "Lemmings saved: " + lemmingsSaved;
		lemmingsDestroyedText.text = "Lemmings destroyed: " + lemmingsDestroyed;
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (nextLevel);
	}

	public void QuitToMenu() {
		SceneManager.LoadScene ("Menu");
	}
}
