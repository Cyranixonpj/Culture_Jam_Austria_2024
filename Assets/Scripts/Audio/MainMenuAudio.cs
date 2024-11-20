using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private Image audioOnButton;
    [SerializeField]private Image audioOffButton;
    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey(""))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted==false)
        {
            audioOnButton.enabled = true;
            audioOffButton.enabled = false;
        }
        else
        {
            audioOnButton.enabled = false;
            audioOffButton.enabled = true;
        }
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    
}
