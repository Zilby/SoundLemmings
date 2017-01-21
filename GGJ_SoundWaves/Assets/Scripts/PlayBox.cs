using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBox : MonoBehaviour {

	public int amountOfLemmingsDestroyed;

	public int GetAmountOfLemmingsDestroyed() {
		return amountOfLemmingsDestroyed;
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			Destroy (col.gameObject);
			amountOfLemmingsDestroyed += 1;
		}
	}
}
