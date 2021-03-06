﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// Check if this CHANGES!!
	//chris plz
	public Collider2D areaOfEffect;
	public bool startEnabled;
	public bool isToggle;

	private AudioSource click;
	public AudioSource loopSound;

	private Animator animator;

	// Use this for initialization
	void Start () {
		areaOfEffect.enabled = startEnabled;
		animator = gameObject.GetComponent<Animator> ();
		click = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isToggle) {
			Toggle ();
		} else {
			ClickAndHold ();
		}
		animator.SetBool ("activated", areaOfEffect.enabled);
		areaOfEffect.gameObject.GetComponent<Animator> ().SetBool ("activated", areaOfEffect.enabled);
		LoopingSound ();
    }

	private void Toggle() {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (gameObject.GetComponent<Collider2D> ().OverlapPoint (mousePosition)) {
				areaOfEffect.enabled = !areaOfEffect.enabled;
				click.Play ();
			}
		}
	}

	private void ClickAndHold() {
		if (Input.GetMouseButton(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (gameObject.GetComponent<Collider2D> ().OverlapPoint (mousePosition)) {
				areaOfEffect.enabled = !startEnabled;
			}
			else {
				areaOfEffect.enabled = startEnabled;
			}
		}
		else {
			areaOfEffect.enabled = startEnabled;
		}
	}

	private void LoopingSound() {
		if (areaOfEffect.enabled) {
			loopSound.UnPause ();
		} else {
			loopSound.Pause ();
		}
	}
}
