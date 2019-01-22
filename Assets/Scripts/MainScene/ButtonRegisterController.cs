using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class ButtonRegisterController : MonoBehaviour, IButtonClick
    {
        GPSController gpsController;
        private void Start()
        {
            gpsController = GameObject.Find("GPSController").GetComponent<GPSController>();
        }
        public void OnClick()
        {
            PlayerPrefs.SetFloat(PlayerPrefsKeys.longitude, gpsController.GetLongitude());
            PlayerPrefs.SetFloat(PlayerPrefsKeys.latitude, gpsController.GetLatitude());
        }
    }
}