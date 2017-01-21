using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera mainCamera;
	public UIManager uiManager;
	public List<Tower> towers;
	public List<KillWall> killWalls;
	public GoalBox goalBox;
	public PlayBox playBox;
	public int winAmount;
	public int lossAmount;

	public int round;
	public string levelTitle;

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
		} else if (GetTotalLemmingsDestroyed () >= lossAmount) {
			GameLoss ();
		} else {
			UpdateInGameUI ();
		}
	}

	private void UpdateInGameUI() {
		uiManager.SetInGame (goalBox.GetAmountOfLemmingsInGoal (), winAmount, lossAmount - GetTotalLemmingsDestroyed (),
			round, levelTitle);
	}

	private int GetTotalLemmingsDestroyed() {
		int total = 0;
		foreach(KillWall kw in killWalls) {
			total += kw.GetAmountOfLemmingsDestroyed ();
		}
		total += playBox.GetAmountOfLemmingsDestroyed ();
		return total;
	}

	private void GameWin() {
		Time.timeScale = 0f;
		uiManager.SetEndLevel (goalBox.GetAmountOfLemmingsInGoal (), playBox.GetAmountOfLemmingsDestroyed (), true);
		audioWin.Play ();
	}

	private void GameLoss() {
		Time.timeScale = 0f;
		uiManager.SetEndLevel (goalBox.GetAmountOfLemmingsInGoal (), playBox.GetAmountOfLemmingsDestroyed (), false);
		audioLoss.Play ();
	}

	private void PauseEverything() {
		Time.timeScale = 0f;
	}
}
