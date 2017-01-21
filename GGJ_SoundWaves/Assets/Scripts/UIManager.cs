using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public Canvas endLevelMenu;
	public Text lemmingsSavedText;
	public Text lemmingsDestroyedText;
	public Image success;
	public Image failure;

	public Canvas inGameUI;
	public Text level;
	public Text score;

	public Canvas pauseMenu;

	public AudioSource pauseOnSound;
	public AudioSource pauseOffSound;


	private string nextLevel;

	private bool paused;

	// Use this for initialization
	void Start () {
		endLevelMenu.enabled = false;
		pauseMenu.enabled = false;
		paused = false;
		success.enabled = false;
		failure.enabled = false;
	}

	void Update() {
		if (Input.GetButtonDown ("Pause") && !endLevelMenu.enabled) {
			Paused ();
		}
	}

	public void SetNextLevel(string nextLevel) {
		this.nextLevel = nextLevel;
	}

	public void Paused() {
		if (!paused) {
			Time.timeScale = 0f;
			inGameUI.enabled = false;
			pauseMenu.enabled = true;
			paused = true;
			pauseOnSound.Play ();
		} else {
			Time.timeScale = 1f;
			inGameUI.enabled = true;
			pauseMenu.enabled = false;
			paused = false;
			pauseOffSound.Play ();
		}
	}

	public void SetInGame(int lemmingsSaved, int lemmingsToSave, int lemmingsLeft, int round, string levelTitle) {
		level.text = "Round " + round + ": " + levelTitle;
		score.text = "Lemmings Left: " + lemmingsLeft + " Score: " + lemmingsSaved + " / " + lemmingsToSave;
	}

	public void SetEndLevel(int lemmingsSaved, int lemmingsDestroyed, bool won) {
		if (won) {
			success.enabled = true;
		} else {
			failure.enabled = true;
		}
		endLevelMenu.enabled = true;
		inGameUI.enabled = false;
		pauseMenu.enabled = false;
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
