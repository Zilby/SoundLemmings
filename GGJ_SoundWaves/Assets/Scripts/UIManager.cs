﻿using System.Collections;
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

	private bool paused;

	// Use this for initialization
	void Start () {
		endLevelMenu.enabled = false;
		pauseMenu.enabled = false;
		paused = false;
	}

	void Update() {
		if (Input.GetButtonDown ("Pause") && !endLevelMenu.enabled) {
			if (!paused) {
				Time.timeScale = 0f;
				inGameUI.enabled = false;
				pauseMenu.enabled = true;
				paused = true;
			} else {
				Time.timeScale = 1f;
				inGameUI.enabled = true;
				pauseMenu.enabled = false;
				paused = false;
			}
		}
	}

	public void SetEndLevel(int lemmingsSaved, int lemmingsDestroyed) {
		endLevelMenu.enabled = true;
		lemmingsSavedText.text = "Lemmings saved: " + lemmingsSaved;
		lemmingsDestroyedText.text = "Lemmings destroyed: " + lemmingsDestroyed;
	}

	public void RestartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (nextLevel);
	}

	public void QuitToMenu() {
		SceneManager.LoadScene ("MainMenu");
	}
}
