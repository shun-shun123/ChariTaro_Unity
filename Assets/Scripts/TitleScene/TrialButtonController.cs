using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Title
{
    public class TrialButtonController : MonoBehaviour, IButtonClick
    {
        #region DebugModeParam
        [SerializeField] Toggle isDebugMode;
        #endregion
        public void OnClick()
        {
            if (isDebugMode.isOn)
            {
                PlayerPrefs.SetInt(PlayerPrefsKeys.isDebugMode, 1);
            }
            else
            {
                PlayerPrefs.DeleteKey(PlayerPrefsKeys.isDebugMode);
            }
            SceneManager.LoadScene("Main");
        }
    }
}