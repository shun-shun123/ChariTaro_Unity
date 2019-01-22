using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionDetector : MonoBehaviour {

    [SerializeField] Text debugTextView;

	IEnumerator Start () {
		if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.compass.enabled = true;
    }
	
	void Update () {
        DebugShow();
	}

    public float GetMagneticHeading()
    {
        return Input.compass.magneticHeading;
    }

    void DebugShow()
    {
        Debug.Log("DirectionDetector: " + Input.compass.magneticHeading);
        debugTextView.text = "DirectionDetector: " + Input.compass.magneticHeading;
    }
}
