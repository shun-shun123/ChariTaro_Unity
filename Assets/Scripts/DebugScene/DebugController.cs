﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {

    #region UI Elements
    [SerializeField] Text horizontalAccuracyText;
    [SerializeField] Text locationDataText;
    [SerializeField] Text northHeadingText;
    [SerializeField] Text savedLocationInfo;
    [SerializeField] GameObject trueHeadingArrow;
    [SerializeField] GameObject magneticHeadingArrow;
    #endregion

    #region DebugParameters
    [Header("DummyDataSettings")]
    [SerializeField] bool setDummyData = true;
    [SerializeField] float dummyLatitude = 30.0f;
    [SerializeField] float dummyLongitude = 135.0f;
    #endregion

    void Start () {
		if (setDummyData)
        {
            PlayerPrefs.SetFloat(PlayerPrefsKeys.latitude, dummyLatitude);
            PlayerPrefs.SetFloat(PlayerPrefsKeys.longitude, dummyLongitude);
        }
    }
	
	// Update is called once per frame
	void Update () {
        horizontalAccuracyText.text = "HorAcc: " + GPSController.GetAccuracy().ToString();
        locationDataText.text = "Lat: " + GPSController.GetLatitude().ToString() + "Long: " + GPSController.GetLongitude();
        northHeadingText.text = "magneticHeading: " + DirectionDetector.GetMagneticHeading().ToString() + " | TrueHeading: " + DirectionDetector.GetTrueHeading().ToString();
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.latitude) && PlayerPrefs.HasKey(PlayerPrefsKeys.longitude))
        {
            savedLocationInfo.text = "Lat: " + PlayerPrefs.GetFloat(PlayerPrefsKeys.latitude) + "Long: " + PlayerPrefs.GetFloat(PlayerPrefsKeys.longitude);
        }
        else
        {
            savedLocationInfo.text = "Location Data is not saved";
        }
        magneticHeadingArrow.transform.rotation = Quaternion.Euler(0, 0, DirectionDetector.GetMagneticHeading());
        trueHeadingArrow.transform.rotation = Quaternion.Euler(0, 0, DirectionDetector.GetTrueHeading());
	}
}
