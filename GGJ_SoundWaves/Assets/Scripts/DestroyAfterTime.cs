using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float timeToDestroy;

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= timeToDestroy) {
			Destroy (gameObject);
		} else {
			timer += Time.deltaTime;
		}
	}
}