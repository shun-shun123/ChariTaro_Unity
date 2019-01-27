using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This class controls direction of smartphone.
/// This class is singlton, so can't copy this instance twice.
/// </summary>
public class DirectionDetector : MonoBehaviour {

    #region Static Fields
    static DirectionDetector instance;
    #endregion
    [SerializeField] Text debugTextView;

	IEnumerator Start () {
		if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.compass.enabled = true;
        instance = this;
    }
	
	void Update () {
        DebugShow();
	}

    public static float GetMagneticHeading()
    {
        return Input.compass.magneticHeading;
    }

    void DebugShow()
    {
        Debug.Log("DirectionDetector: " + Input.compass.magneticHeading);
        debugTextView.text = "DirectionDetector: " + Input.compass.magneticHeading;
    }
}
