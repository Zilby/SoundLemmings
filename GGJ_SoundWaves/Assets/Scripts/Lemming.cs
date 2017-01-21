using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemming : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.down * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetDirection(Vector2 dir) {
		rb.velocity = dir.normalized * speed;
	}

	void FixedUpdate() {
		rb.velocity = rb.velocity.normalized * speed;
	}
}
