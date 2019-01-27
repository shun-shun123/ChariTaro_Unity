using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class ButtonRegisterController : MonoBehaviour, IButtonClick
    {
        public void OnClick()
        { 
            PlayerPrefs.SetFloat(PlayerPrefsKeys.longitude, GPSController.GetLongitude());
            PlayerPrefs.SetFloat(PlayerPrefsKeys.latitude, GPSController.GetLatitude());
        }
    }
}