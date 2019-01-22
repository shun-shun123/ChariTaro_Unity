using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeDetector : MonoBehaviour {

    [SerializeField] Text debugTextView;

    private Vector3 preAcceleration;
    private Vector3 acceleration;
    private float dotVec;
    private int shakeCount = 0;
	
	void Update () {
        ShakeDetect();
        DebugShow();
	}

    void ShakeDetect()
    {
        preAcceleration = acceleration;
        acceleration = Input.acceleration;
        dotVec = Vector3.Dot(preAcceleration, acceleration);
        if (dotVec < 0)
        {
            Debug.Log("Shaken");
            shakeCount++;
        }
    }

    void DebugShow()
    {
        Debug.Log("ShakeDetector: " + shakeCount);
        debugTextView.text = shakeCount.ToString();
    }
}
