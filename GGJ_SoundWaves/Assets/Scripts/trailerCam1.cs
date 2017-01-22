using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerCam1 : MonoBehaviour {

	public float zoomDelay = 4.5f;
	public float zoomSpeed = 0.0f;
	public float zoomAccel = 0.001f;

	private float time = 0;

	// Update is called once per frame
	void Update () {
		if (time > zoomDelay) {
			zoomSpeed += zoomAccel;
		}
		time += Time.deltaTime;
		gameObject.GetComponent<Camera> ().orthographicSize += zoomSpeed * Time.deltaTime;
	}
}
