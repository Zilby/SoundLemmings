using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour {

	private int amountOfLemmingsDestroyed;

	public AudioSource killSound;

	public int GetAmountOfLemmingsDestroyed() {
		return amountOfLemmingsDestroyed;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			col.gameObject.GetComponent<Lemming> ().Death ();
			amountOfLemmingsDestroyed += 1;
			killSound.Play ();
		}
	}
}
