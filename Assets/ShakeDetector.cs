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
    int shakeMaxCount = 5;
    [SerializeField]
    bool isDebugShown = true;
    #endregion

    #region Private Fields
    private Vector3 preAcceleration;
    private Vector3 acceleration;
    private float dotVec;
    private float lastShakenTime;
    private const float SHAKETIMEOUT = 0.5f;
    private int shakeCount = 0;
    #endregion

    private void Start()
    {
        instance = this;
    }

    void Update () {
        ShakeDetect();
        if (shakeCount >= 8 && !PlayerPrefs.HasKey(PlayerPrefsKeys.latitude) && !PlayerPrefs.HasKey(PlayerPrefsKeys.longitude))
        {
            SaveCurrentLocation();
        }
        if (isDebugShown)
        {
            DebugShow();
        }
    }

    void ShakeDetect()
    {
        preAcceleration = acceleration;
        acceleration = Input.acceleration;
        dotVec = Vector3.Dot(preAcceleration, acceleration);
        // シェイクを検知
        if (dotVec < 0)
        {
            // 前回のシェイク検知から間が空いていたら1度目のシェイクとして受け取る
            if (Time.time - lastShakenTime >= SHAKETIMEOUT)
            {
                shakeCount = 1;
                Debug.Log("<Color=Red>SHAKETIMEOUT</Color>");
                lastShakenTime = Time.time;
                return;
            }
            // 前回のシェイク検知から連続した検知なら
            else
            {
                Debug.Log("<Color=Red>Continueing Shaking</Color>");
                lastShakenTime = Time.time;
                shakeCount++;
            }
        }
    }

    void SaveCurrentLocation()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKeys.latitude, GPSController.GetLatitude());
        PlayerPrefs.SetFloat(PlayerPrefsKeys.longitude, GPSController.GetLongitude());
    }

    void DebugShow()
    {
        Debug.LogFormat("<Color=Blue><a>ShakeCount</a></Color>: {0}", shakeCount);
    }
}
