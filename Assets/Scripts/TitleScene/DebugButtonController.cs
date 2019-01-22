using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title{
    public class DebugButtonController : MonoBehaviour, IButtonClick {
        public void OnClick()
        {
            SceneManager.LoadScene("Debug");
        }
    }
}