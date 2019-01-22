using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class ArrowController : MonoBehaviour
    {
        private float lastLongitude = 0.0f;
        private float lastLatitude = 0.0f;
        private float longitude;
        private float latitude;
        GPSController gpsController;
        DirectionDetector directionDetector;

        [Header("StateButton")]
        [SerializeField] Button registerButton;
        [SerializeField] Button resetButton;
        [SerializeField] bool isReset = true;

        [SerializeField] Text debugTextView;

        private void Start()
        {
            lastLongitude = PlayerPrefs.GetFloat(PlayerPrefsKeys.longitude, -1.0f);
            lastLatitude = PlayerPrefs.GetFloat(PlayerPrefsKeys.latitude, -1.0f);
            // データがセットされていなかった時
            if (lastLongitude < 0.0f || lastLatitude < 0.0f)
            {
                Debug.Log("Faild to Get Last Data");
                isReset = false;
            }
            registerButton.gameObject.SetActive(!isReset);
            resetButton.gameObject.SetActive(isReset);
            gpsController = GameObject.Find("GPSController").GetComponent<GPSController>();
            directionDetector = GameObject.Find("DirectionDetector").GetComponent<DirectionDetector>();
        }

        private void Update()
        {
            longitude = gpsController.GetLongitude();
            latitude = gpsController.GetLatitude();
            float diffLong = lastLongitude - longitude;
            float diffLat = lastLatitude - latitude;
            debugTextView.text = diffLat + ":" + diffLong;
            float toNorthAngle = directionDetector.GetMagneticHeading();
            transform.rotation = Quaternion.Euler(0, 0, toNorthAngle);
        }
    }
}
