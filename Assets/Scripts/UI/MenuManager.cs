using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _creditsView;
    private bool _isCreditsScene;


    private void Awake()
    {
        _mainView.SetActive(true);
        _creditsView.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown && _isCreditsScene)
        {
            QuitToMainMenu();
        }
    }

    #region mainView

    public void StartClicked()
    {
        _mainView.SetActive(false);
        SceneManager.LoadScene("Levels");
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
        _creditsView.SetActive(true);
        _isCreditsScene = true;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        _isCreditsScene = false;
    }

    #endregion
}