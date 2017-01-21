using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingSpawner : MonoBehaviour {

	public Lemming lemmingPrefab;

	public float spawnDelay;
	public int lemmingSpawnLimit;

	private float timer;
	private int lemmingsSpawned;

	// Use this for initialization
	void Start () {
		timer = 0f;
		lemmingsSpawned = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (lemmingsSpawned >= lemmingSpawnLimit) {
			if (timer >= spawnDelay) {
				timer = 0f;
				Instantiate (lemmingPrefab, gameObject.transform.position, Quaternion.identity);
			} else {
				timer += Time.deltaTime;
			}
		}
	}
}
