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
	public Button continueButton;

	public Canvas inGameUI;
	public Text level;
	public Text score;

	public Canvas pauseMenu;

	public AudioSource pauseOnSound;
	public AudioSource pauseOffSound;

	private string nextLevel;

	private bool paused;

	private ArrayList towers;

	// Use this for initialization
	void Start () {
		endLevelMenu.enabled = false;
		pauseMenu.enabled = false;
		paused = false;
		success.enabled = false;
		failure.enabled = false;

		towers = new ArrayList ();
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Tower")) {
			towers.Add (g.GetComponent<Tower> ());
		}
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
			PausePlay (true);
			pauseMenu.enabled = true;
			paused = true;
			pauseOnSound.Play ();
		} else {
			PausePlay (false);
			pauseMenu.enabled = false;
			paused = false;
			pauseOffSound.Play ();
		}
	}

	public void PausePlay(bool shouldPause) {
		if (shouldPause) {
			Time.timeScale = 0f;
			inGameUI.enabled = false;
			foreach (Tower g in towers) {
				g.enabled = false;
			}
		} else {
			Time.timeScale = 1f;
			inGameUI.enabled = true;
			foreach (Tower g in towers) {
				g.enabled = true;
			}
		}
	}

	public void SetInGame(int lemmingsSaved, int lemmingsToSave, int lemmingsLeft, int round, string levelTitle) {
		level.text = "Stage " + round + ": " + levelTitle;
		score.text = "Lives Remaining: " + (lemmingsLeft - 1) + "     Score: " + lemmingsSaved + " / " + lemmingsToSave;
		lemmingsSavedText.text = "Saved: " + lemmingsSaved + " / " + lemmingsToSave;
	}

	public void SetEndLevel(int lemmingsSaved, int lemmingsDestroyed, bool won) {
		if (won) {
			continueButton.enabled = true;
			continueButton.gameObject.GetComponent<Image> ().enabled = true;
			success.enabled = true;
		} else {
			continueButton.enabled = false;
			continueButton.gameObject.GetComponent<Image> ().enabled = false;
			failure.enabled = true;
		}
		endLevelMenu.enabled = true;
		inGameUI.enabled = false;
		pauseMenu.enabled = false;
		//lemmingsSavedText.text = "Saved: " + lemmingsSaved + " / " + ;
		lemmingsDestroyedText.text = "Destroyed: " + lemmingsDestroyed;
	}

	public void RestartLevel() {
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void LoadNextLevel() {
		Time.timeScale = 1f;
		SceneManager.LoadScene (nextLevel);
	}

	public void QuitToMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
}
