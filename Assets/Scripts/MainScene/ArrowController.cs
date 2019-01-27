using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class ArrowController : MonoBehaviour
    {
        #region Private Fields
        private float lastLongitude = 0.0f;
        private float lastLatitude = 0.0f;
        private float longitude;
        private float latitude;
        #endregion

        // 現在位置と登録位置の差から方角を取り出すための変数
        // latitude, longitude
        Vector2 toNorth = new Vector2(0.0f, 1.0f);

        private void OnEnable()
        {
            if (UiController.isSavedLocationData)
            {
                lastLatitude = PlayerPrefs.GetFloat(PlayerPrefsKeys.latitude);
                lastLongitude = PlayerPrefs.GetFloat(PlayerPrefsKeys.longitude);
            }
        }

        private void Update()
        {
            latitude = GPSController.GetLatitude();
            longitude = GPSController.GetLongitude();
            float diffLat = lastLatitude - latitude;
            float diffLong = lastLongitude - longitude;
            float toNorthAngle =  (DirectionDetector.GetMagneticHeading() + DirectionDetector.GetTrueHeading()) / 2.0f;
            Vector2 diffVector = new Vector2(diffLong, diffLat);
            float angle = Vector2.Angle(toNorth, diffVector);
            transform.rotation = Quaternion.Euler(0, 0, toNorthAngle + angle);
        }
    }
}
