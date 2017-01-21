using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Collider2D areaOfEffect;
	public bool startEnabled;

	// Use this for initialization
	void Start () {
		areaOfEffect.enabled = startEnabled;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition)) {
                areaOfEffect.enabled = !areaOfEffect.enabled;
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
