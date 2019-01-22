using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DebugScene
{
    public class ButtonBackController : MonoBehaviour, IButtonClick
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Title");
        }
    }
}
