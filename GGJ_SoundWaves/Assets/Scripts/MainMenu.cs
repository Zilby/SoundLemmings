using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string firstLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			Application.Quit ();
		}
	}

	public void Play() {
		SceneManager.LoadScene (firstLevel);
	}

	public void LevelSelect() {
		SceneManager.LoadScene ("LevelSelect");
	}

	public void Credits() {
		SceneManager.LoadScene ("Credits");
	}
}
