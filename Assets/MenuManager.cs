using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;


    private void Start()
    {
        _mainView.SetActive(true);
    }

    #region mainView

    public void StartClicked()
    {
        _mainView.SetActive(false);
        SceneManager.LoadScene("SomeScene");
    }
    public void ExitClicked()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void MuteClicked()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    public void CreditsClicked()
    {
        _mainView.SetActive(false);
        SceneManager.LoadScene("CreditsScene");
    }
    #endregion
} 
