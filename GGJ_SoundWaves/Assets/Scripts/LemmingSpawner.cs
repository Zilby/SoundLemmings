using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingSpawner : MonoBehaviour {

	public Lemming lemmingPrefab;
    public bool usesTrigger;

	public float spawnDelay;
	public int lemmingSpawnLimit;
	public Vector2 initialDirection;

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
		Lemming temp = Instantiate (lemmingPrefab, gameObject.transform.position,
			Quaternion.identity);
		temp.SetDirection (new Vector2(Mathf.Cos(gameObject.transform.rotation.z * ((2f * Mathf.PI) / 180f)),
			Mathf.Sin(gameObject.transform.rotation.z * ((2f * Mathf.PI) / 180f))));
        lemmingsSpawned += 1;
    }
}
