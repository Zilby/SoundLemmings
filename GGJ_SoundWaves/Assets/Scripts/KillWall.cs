using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour {

	private int amountOfLemmingsDestroyed;

	public int GetAmountOfLemmingsDestroyed() {
		return amountOfLemmingsDestroyed;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			Destroy (col.gameObject);
			amountOfLemmingsDestroyed += 1;
		}
	}
}
