using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Camera mainCamera;
	public UIManager uiManager;
	public int winAmount;
	public int lossAmount;

	public int round;
	public string levelTitle;
	public string nextLevel;

	public AudioSource audioWin;
	public AudioSource audioLoss;
	public AudioSource audioMusic;

	private bool gameOver;

	private ArrayList towers;
	private ArrayList killWalls;
	private ArrayList goalBoxes;
	private PlayBox playBox;

	// Use this for initialization
	void Awake () {
		towers = new ArrayList ();
		killWalls = new ArrayList ();
		goalBoxes = new ArrayList ();
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Tower")) {
			towers.Add (g.GetComponent<Tower> ());
		}
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("KillWall")) {
			killWalls.Add (g.GetComponent<KillWall> ());
		}
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("GoalBox")) {
			goalBoxes.Add (g.GetComponent<GoalBox> ());
		}
		playBox = GameObject.FindGameObjectWithTag ("PlayBox").GetComponent<PlayBox> ();
		uiManager.SetNextLevel (nextLevel);
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			if (GetTotalLemmingsSaved () >= winAmount) {
				GameWin ();
				gameOver = true;
			} else if (GetTotalLemmingsDestroyed () >= lossAmount) {
				GameLoss ();
				gameOver = true;
			} else if (Input.GetButtonDown("Restart")){
				uiManager.RestartLevel ();
			} else {
				UpdateInGameUI ();
			}
		}
	}

	private void UpdateInGameUI() {
		uiManager.SetInGame (GetTotalLemmingsSaved (), winAmount, lossAmount - GetTotalLemmingsDestroyed (),
			round, levelTitle);
	}

	private int GetTotalLemmingsSaved() {
		int total = 0;
		foreach (GoalBox gb in goalBoxes) {
			total += gb.GetAmountOfLemmingsInGoal ();
		}
		return total;
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
		uiManager.SetEndLevel (GetTotalLemmingsSaved (), GetTotalLemmingsDestroyed (), true);
		audioWin.Play ();
	}

	private void GameLoss() {
		Time.timeScale = 0f;
		uiManager.SetEndLevel (GetTotalLemmingsSaved (), GetTotalLemmingsDestroyed (), false);
		audioLoss.Play ();
	}

	private void PauseEverything() {
		Time.timeScale = 0f;
	}
}