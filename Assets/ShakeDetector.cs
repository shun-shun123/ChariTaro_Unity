using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class controls shake detection.
/// This class is singlton, can't copy twice.
/// </summary>
public class ShakeDetector : MonoBehaviour {

    #region Static Fields
    static ShakeDetector instance;
    #endregion
    #region Private Serialize Fields
    [SerializeField]
    Text debugTextView;
    [SerializeField]
    Text shakeNoticeTextView;
    [SerializeField]
    int shakeMaxCount = 5;
    #endregion

    #region Private Fields
    private Vector3 preAcceleration;
    private Vector3 acceleration;
    private float dotVec;
    private int shakeCount = 0;
    #endregion

    void Update () {
        ShakeDetect();
        DebugShow();
        instance = this;
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
        else
        {
            Debug.Log("Stop Shaken");
            shakeCount = 0;
        }
    }

    void DebugShow()
    {
        Debug.Log("ShakeDetector: " + shakeCount);
        debugTextView.text = shakeCount.ToString();
        if (shakeCount >= shakeMaxCount)
        {
            shakeNoticeTextView.gameObject.SetActive(true);
        }
        else
        {
            shakeNoticeTextView.gameObject.SetActive(false);
        }
    }
}
