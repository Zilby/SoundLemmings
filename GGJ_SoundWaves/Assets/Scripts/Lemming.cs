﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemming : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.AddForce (Vector2.down * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
