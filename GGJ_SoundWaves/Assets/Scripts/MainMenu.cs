﻿using System.Collections;
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
		
	}

	public void Play() {
		SceneManager.LoadScene (firstLevel);
	}

	public void Credits() {
		SceneManager.LoadScene ("LevelSelect");
	}
}
