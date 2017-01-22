using System.Collections;
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

	private Animator animator;


	// Use this for initialization
	void Start () {
		timer = 0f;
		lemmingsSpawned = 0;
		initDelay += 1f;
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lemmingsSpawned < lemmingSpawnLimit) {
			if (lemmingsSpawned == 0) {
				if (timer >= initDelay) {
					timer = 0f;
					Spawn ();
				} else {
					timer += Time.deltaTime;
				}
				if ((timer + 0.75f) >= initDelay) {
					animator.SetBool ("spawning", true);
				} else {
					animator.SetBool ("spawning", false);
				}
			} else if (!usesTrigger) {
				if (timer >= spawnDelay) {
					timer = 0f;
					Spawn ();
				} else {
					timer += Time.deltaTime;
				}
				if ((timer + 0.75f) >= spawnDelay) {
					animator.SetBool ("spawning", true);
				} else {
					animator.SetBool ("spawning", false);
				}
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