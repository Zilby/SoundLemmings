﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// Check if this CHANGES!!

	public Collider2D areaOfEffect;
	public bool startEnabled;
	public bool isToggle;

	private Animator animator;

	// Use this for initialization
	void Start () {
		areaOfEffect.enabled = startEnabled;
		animator = gameObject.GetComponent<Animator> ();
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
    }

	private void Toggle() {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (gameObject.GetComponent<Collider2D> ().OverlapPoint (mousePosition)) {
				areaOfEffect.enabled = !areaOfEffect.enabled;
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
}
