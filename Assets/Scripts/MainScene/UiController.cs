﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class changes Main Ui by judgin whether location data is saved or not
/// This class is singlton, so can't copy twice.
/// </summary>
public class UiController : MonoBehaviour {

    public static UiController instance;
    public static bool isSavedLocationData = false;
    [Tooltip("If location data is not saved. Show this UI")]
    [SerializeField]
    GameObject notSavedUi;
    [Tooltip("If location data is saved. Show this UI")]
    [SerializeField]
    GameObject savedUi;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.isDebugMode))
        {
            SceneManager.LoadScene("Debug", LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        instance = this;
        isSavedLocationData = PlayerPrefs.HasKey(PlayerPrefsKeys.latitude);
    }
    void Update () {
		if (isSavedLocationData)
        {
            savedUi.SetActive(true);
            notSavedUi.SetActive(false);
        }
        else
        {
            notSavedUi.SetActive(true);
            savedUi.SetActive(false);
        }
    }
}
