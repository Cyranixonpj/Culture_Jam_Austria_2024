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
    [SerializeField] private AudioSource _buttonSound;
    private bool _isCreditsScene;


    private void Awake()
    {
        _buttonSound.Stop();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.GetInt("ShowCredits", 0) == 1)
        {
            ShowCreditsImmediately();
        }
        else
        {
            _mainView.SetActive(true);
            _creditsView.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && _isCreditsScene)
        {
            QuitToMainMenu();
        }
    }

    private void ShowCreditsImmediately()
    {
        PlayerPrefs.SetInt("ShowCredits", 0); // Reset, żeby za każdym razem nie pokazywało
        _mainView.SetActive(false);
        _creditsView.SetActive(true);
        _isCreditsScene = true;
    }

    #region mainView

    public void StartClicked()
    {
        _mainView.SetActive(false);

        // SceneManager.LoadSceneAsync("PN_AllAreas");
        StartCoroutine(LoadSceneWithLoadingScreen("PN_AllAreas"));
    }

    private IEnumerator LoadSceneWithLoadingScreen(string sceneName)
    {
        // Załaduj ekran ładowania
        AsyncOperation loadLoadingScreen = SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        loadLoadingScreen.allowSceneActivation = true; // Od razu aktywuj scenę

        // Czekaj, aż scena ładowania zostanie w pełni załadowana
        while (!loadLoadingScreen.isDone)
        {
            yield return null;
        }

        // Załaduj główną scenę asynchronicznie w tle
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        // Poczekaj, aż scena się załaduje (do 90%)
        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        // Dopiero po załadowaniu 90% sceny, aktywuj ją
        asyncOperation.allowSceneActivation = true;

        // Usuń ekran ładowania
        SceneManager.UnloadSceneAsync("LoadingScreen");
    }

    public void ExitClicked()
    {
        StartCoroutine(QuitWithDelay());
    }

    private IEnumerator QuitWithDelay()
    {
        _buttonSound.Play();
        yield return new WaitForSeconds(0.5f);
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        
        #else
        Application.Quit();
        #endif
        
    }


    public void MuteClicked()
    {
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _isCreditsScene = false;
    }

    #endregion
}