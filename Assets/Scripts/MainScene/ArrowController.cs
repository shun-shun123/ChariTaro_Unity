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

        [Header("StateButton")]
        [SerializeField] Button registerButton;
        [SerializeField] Button resetButton;
        [SerializeField] bool isReset = true;

        [SerializeField] Text debugTextView;

        // 現在位置と登録位置の差から方角を取り出すための変数
        // latitude, longitude
        Vector2 toNorth = new Vector2(10.0f, 0.0f);

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
        }

        private void Update()
        {
            longitude = GPSController.GetLongitude();
            latitude = GPSController.GetLatitude();
            float diffLong = lastLongitude - longitude;
            float diffLat = lastLatitude - latitude;
            debugTextView.text = diffLat + ":" + diffLong;
            float toNorthAngle = DirectionDetector.GetMagneticHeading();
            Vector2 diffVector = new Vector2(diffLat, diffLong);
            float angle = Vector2.Angle(toNorth, diffVector);
            transform.rotation = Quaternion.Euler(0, 0, toNorthAngle + angle);
        }
    }
}
