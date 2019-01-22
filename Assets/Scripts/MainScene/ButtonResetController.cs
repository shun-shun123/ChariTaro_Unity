using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class ButtonResetController : MonoBehaviour, IButtonClick
    {
        public void OnClick()
        {
            PlayerPrefs.DeleteKey(PlayerPrefsKeys.longitude);
            PlayerPrefs.DeleteKey(PlayerPrefsKeys.latitude);
        }
    }
}