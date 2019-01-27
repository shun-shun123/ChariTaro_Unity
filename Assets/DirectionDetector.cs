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

    #region Private Serialized Fields
    [SerializeField]
    bool isDebugShown = true;
    #endregion

    IEnumerator Start () {
		if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.compass.enabled = true;
        instance = this;
    }
	
	void Update () {
        if (isDebugShown)
        {
            DebugShow();
        }
	}

    public static float GetMagneticHeading()
    {
        return Input.compass.magneticHeading;
    }

    void DebugShow()
    {
        Debug.Log("<Color=Red><a>MagneticHeading</a></Color>: " + Input.compass.magneticHeading);
    }
}
