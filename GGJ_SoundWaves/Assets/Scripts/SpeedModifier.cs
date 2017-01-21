using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : MonoBehaviour {

	public float modifier = 0.5f;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			col.gameObject.GetComponent<Lemming>().AdjSpeed(modifier);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			col.gameObject.GetComponent<Lemming>().AdjSpeed(1 / modifier);
		}
	}
}
