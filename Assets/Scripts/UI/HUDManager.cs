using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource _button;
    
    private bool _isPause;
    void Awake()
    {
        _button.Stop();
        _pauseView.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        Time.timeScale = 0f;
        _isPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        _player.GetComponent<PlayerMovement>().enabled = false;
        
    }

    public void ResumeGame()
    {
        _pauseView.SetActive(false);
        Time.timeScale = 1f;
        _isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void MuteGame()
    {
        ///Mute the game
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene("MainMenu");
        StartCoroutine(QuitToMainMenuDelay());
    }


    private IEnumerator QuitToMainMenuDelay()
    {
        _button.Play();

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
