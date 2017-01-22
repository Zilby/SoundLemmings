using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	public GameObject text;
	public float scrollSpeed = 150;

	// Use this for initialization
	void Start () {
		//text.transform.position.y -= 700;
	}
	
	// Update is called once per frame
	void Update () {
		text.transform.position = text.transform.position + new Vector3 (0, scrollSpeed, 0) * Time.deltaTime;
	}
}
