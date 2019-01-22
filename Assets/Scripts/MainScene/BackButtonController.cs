using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class BackButtonController : MonoBehaviour, IButtonClick
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Title");
        }
    }
}