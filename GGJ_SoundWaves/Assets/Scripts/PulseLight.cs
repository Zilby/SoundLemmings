using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour {

	public float pulseSpeed;

	private Light pulseLight;
	private float maxIntensity;
	private bool isDecreasing;

	// Use this for initialization
	void Start () {
		pulseLight = gameObject.GetComponent<Light> ();
		maxIntensity = pulseLight.intensity;
		isDecreasing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDecreasing && pulseLight.intensity <= 0f) {
			pulseLight.intensity = 0f;
			isDecreasing = false;
		} else if (!isDecreasing && pulseLight.intensity >= maxIntensity) {
			pulseLight.intensity = maxIntensity;
			isDecreasing = true;
		}
		if (isDecreasing && pulseLight.intensity > 0f) {
			pulseLight.intensity -= Time.deltaTime * pulseSpeed;
		} else if (!isDecreasing && pulseLight.intensity < maxIntensity) {
			pulseLight.intensity += Time.deltaTime * pulseSpeed;
		}
	}

	public void SetTo(bool active) {
		pulseLight.enabled = active;
	}
}