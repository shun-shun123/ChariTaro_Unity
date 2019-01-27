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

    #region Private Serialized Fields
    [Header("Shake Detection Parameters")]
    [Tooltip("TimeOut for shake detection")]
    [SerializeField]
    private float SHAKETIMEOUT = 0.5f;
    [Tooltip("The times of shaken for shake detection")]
    [SerializeField]
    private int shakenCount = 6;
    #endregion

    #region Private Fields
    private Vector3 preAcceleration;
    private Vector3 acceleration;
    private float dotVec;
    private float lastShakenTime;
    private int shakeCount = 0;
    #endregion

    private void Start()
    {
        instance = this;
    }

    void Update () {
        ShakeDetect();
        if (shakeCount >= shakenCount && !PlayerPrefs.HasKey(PlayerPrefsKeys.latitude) && !PlayerPrefs.HasKey(PlayerPrefsKeys.longitude))
        {
            SaveCurrentLocation();
            shakeCount = 0;
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
                lastShakenTime = Time.time;
                return;
            }
            // 前回のシェイク検知から連続した検知なら
            else
            {
                lastShakenTime = Time.time;
                shakeCount++;
            }
        }
    }

    void SaveCurrentLocation()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKeys.latitude, GPSController.GetLatitude());
        PlayerPrefs.SetFloat(PlayerPrefsKeys.longitude, GPSController.GetLongitude());
        // UiControllerに保存処理を通達し、UIを変更する
        UiController.isSavedLocationData = true;
    }

    void DebugShow()
    {
        Debug.LogFormat("<Color=Blue><a>ShakeCount</a></Color>: {0}", shakeCount);
    }
}
