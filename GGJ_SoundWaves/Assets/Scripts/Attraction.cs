using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour {

	public float strength;
	public bool isAttract;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Lemming") {
			Vector2 from;
			Vector2 to;
			if (isAttract) {
				from = col.gameObject.transform.position;
				to = gameObject.transform.position;
			} else {
				from = gameObject.transform.position;
				to = col.gameObject.transform.position;
			}
			Vector2 dir = new Vector2 (to.x - from.x,
				              to.y - from.y);
			float force = Mathf.Pow((gameObject.transform.localScale.x - dir.magnitude), 2) /
				Mathf.Pow(gameObject.transform.localScale.x, 2);
			dir = dir.normalized * force * strength;
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (dir);
		}
	}
}