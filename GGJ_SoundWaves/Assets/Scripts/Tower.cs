using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// Check if this CHANGES!!

	public Collider2D areaOfEffect;
	public bool startEnabled;

	private Animator animator;

	// Use this for initialization
	void Start () {
		areaOfEffect.enabled = startEnabled;
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition)) {
                areaOfEffect.enabled = !areaOfEffect.enabled;
				animator.SetBool ("activated", areaOfEffect);
                if (areaOfEffect.enabled) {
                    areaOfEffect.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else {
                    areaOfEffect.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }
}
