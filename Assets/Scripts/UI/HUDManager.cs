using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseView;
    
    private bool _isPause;
    void Awake()
    {
        _pauseView.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        
    }

    public void PauseGame()
    {
        _pauseView.SetActive(true);
        _isPause = true;
        
    }

    public void ResumeGame()
    {
        _pauseView.SetActive(false);
        _isPause = false;

    }

    public void MuteGame()
    {
        ///Mute the game
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
