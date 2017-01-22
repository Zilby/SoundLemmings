using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour {

	private int amountOfLemmingsInGoal;

	public AudioSource goalSound;

	// Use this for initialization
	void Start () {
		amountOfLemmingsInGoal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			col.gameObject.GetComponent<Lemming> ().Victory ();
			amountOfLemmingsInGoal += 1;
			goalSound.Play ();
		}
	}

	public int GetAmountOfLemmingsInGoal() {
		return amountOfLemmingsInGoal;
	}
}
