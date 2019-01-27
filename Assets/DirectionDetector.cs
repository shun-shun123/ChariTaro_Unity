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

    IEnumerator Start() {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.compass.enabled = true;
        instance = this;
    }

    void Update() {
        if (isDebugShown)
        {
            DebugShow();
        }
    }

    public static float GetMagneticHeading()
    {
        return Input.compass.magneticHeading;
    }

    public static float GetTrueHeading()
    {
        return Input.compass.trueHeading;
    }

    void DebugShow()
    {
        Debug.Log("<Color=Red><a>MagneticHeading</a></Color>: " + Input.compass.magneticHeading);
        Debug.Log("<Color=Red>trueHeading</Color>: " + Input.compass.trueHeading);
        Debug.Log("<Color=Red>headingAccuracy</Color>: " + Input.compass.headingAccuracy);
    }
}
