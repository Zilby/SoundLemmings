using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour {

	public AudioSource bounceSound;

	void OnCollisionEnter2D(Collision2D col) {
			bounceSound.Play ();
	}
}
