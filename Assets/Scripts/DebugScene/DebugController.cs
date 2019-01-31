using System.Collections;
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
    [SerializeField] Text diffAngleText;
    #endregion

    #region DebugParameters
    [Header("DummyDataSettings")]
    [SerializeField] bool setDummyData = true;
    [SerializeField] float dummyLatitude = 30.0f;
    [SerializeField] float dummyLongitude = 135.0f;
    #endregion

    Vector2 toNorth = new Vector2(1.0f, 0.0f);

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
        northHeadingText.text = "magneticHeading: " + DirectionDetector.GetMagneticHeading().ToString() + "\nTrueHeading: " + DirectionDetector.GetTrueHeading().ToString();
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.latitude) && PlayerPrefs.HasKey(PlayerPrefsKeys.longitude))
        {
            savedLocationInfo.text = "Lat: " + PlayerPrefs.GetFloat(PlayerPrefsKeys.latitude) + "Long: " + PlayerPrefs.GetFloat(PlayerPrefsKeys.longitude);
        }
        else
        {
            savedLocationInfo.text = "Location Data is not saved";
        }
        float diffLat = PlayerPrefs.GetFloat(PlayerPrefsKeys.latitude) - GPSController.GetLatitude();
        float diffLong = PlayerPrefs.GetFloat(PlayerPrefsKeys.longitude) - GPSController.GetLongitude();
        Vector2 diffVector = new Vector2(diffLat, diffLong);
        float angle = Vector2.Angle(toNorth, diffVector);
        diffAngleText.text = "DiffAngle: " + angle + "\nFinalAngle: " + (angle + DirectionDetector.GetMagneticHeading());
        magneticHeadingArrow.transform.rotation = Quaternion.Euler(0, 0, DirectionDetector.GetMagneticHeading());
        trueHeadingArrow.transform.rotation = Quaternion.Euler(0, 0, DirectionDetector.GetTrueHeading());
	}
}
