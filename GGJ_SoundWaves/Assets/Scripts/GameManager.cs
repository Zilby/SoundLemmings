using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera mainCamera;
	public UIManager uiManager;
	public List<Tower> towers;
	public GoalBox goalBox;
	public PlayBox playBox;
	public int winAmount;
	public int lossAmount;

	public AudioSource audioWin;
	public AudioSource audioLoss;
	public AudioSource audioMusic;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (goalBox.GetAmountOfLemmingsInGoal () >= winAmount) {
			GameWin ();
		} else if (playBox.GetAmountOfLemmingsDestroyed () >= lossAmount) {
			GameLoss ();
		}
	}

	private void GameWin() {
		uiManager.SetEndLevel (goalBox.GetAmountOfLemmingsInGoal (), playBox.GetAmountOfLemmingsDestroyed ());
		audioWin.Play ();
	}

	private void GameLoss() {
		audioLoss.Play ();
	}

	private void PauseEverything() {
		Time.timeScale = 0f;
	}
}
