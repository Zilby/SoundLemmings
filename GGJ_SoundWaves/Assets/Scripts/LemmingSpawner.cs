using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingSpawner : MonoBehaviour {

	public Lemming lemmingPrefab;
    public bool usesTrigger;

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
        if (lemmingsSpawned == 0)
        {
            Spawn();
        }
        if (!usesTrigger)
        {
            if (lemmingsSpawned <= lemmingSpawnLimit)
            {
                if (timer >= spawnDelay)
                {
                    timer = 0f;
                    Spawn();
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
	}

    public void Spawn ()
    {
        Instantiate(lemmingPrefab, gameObject.transform.position, Quaternion.identity);
        lemmingsSpawned += 1;
    }
}
