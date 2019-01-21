using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetector : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.compass.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Direction: " + Input.compass.magneticHeading);
	}
}
