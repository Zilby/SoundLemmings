﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingSpawner : MonoBehaviour {

	public Lemming lemmingPrefab;
	public TriggerZone trig;
    
	public bool usesTrigger;
	public float initDelay;
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
		if (lemmingsSpawned < lemmingSpawnLimit) {
			if (timer >= initDelay) {
				if (lemmingsSpawned == 0) {
					timer = 0f;
					Spawn ();
				} else if (!usesTrigger) {
					if (timer >= spawnDelay) {
						timer = 0f;
						Spawn ();
					} else {
						timer += Time.deltaTime;
					}
				}
			} else {
				timer += Time.deltaTime;
			}
		} else {
			Destroy (gameObject);
		}
	}

    public void Spawn ()
    {
		Lemming temp = Instantiate (lemmingPrefab, gameObject.transform.position,
			Quaternion.identity);
		float z = gameObject.transform.rotation.eulerAngles.z;
		temp.SetDirection (new Vector2(Mathf.Cos(z * (Mathf.PI / 180)),
			Mathf.Sin(z * (Mathf.PI / 180))));
        lemmingsSpawned += 1;
    }
}
