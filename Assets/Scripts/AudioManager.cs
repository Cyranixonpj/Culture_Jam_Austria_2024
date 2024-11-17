using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Dialogue;
    [SerializeField] AudioSource SnowWalk;
    [SerializeField]  AudioSource TavernWalk;
    [SerializeField] AudioSource windSource;
    //[SerializeField] AudioSource tavernMusic;
    public bool tavern;
    

    private void Start()
    {
        PlayBackgroundMusic();
    }

    
    public void PlayBackgroundMusic()
    {
        if(tavern)
        {
            windSource.Stop();
            //tavernMusic.Play();
        }
        else
        {
            windSource.Play();
            //tavernMusic.Stop();
        }
        
    }
    public void setTavern()
    {
        tavern = true;
        SnowWalk.Stop();
        PlayBackgroundMusic(); 
    }

    public void setOutsied()
    {
        tavern = false;
        TavernWalk.Stop();
        PlayBackgroundMusic();
    }

    public void StartWalk()
    {
        if (tavern)
        {
            if (!TavernWalk.isPlaying)
            {
                TavernWalk.loop = true;
                TavernWalk.Play();
            }
        }
        else
        {
            if (!SnowWalk.isPlaying)
            {
                SnowWalk.loop = true;
                SnowWalk.Play();
            }
        }
    }

    public void StopWalk()
    {
       
        if (tavern)
        {
            TavernWalk.loop = false;
            TavernWalk.Stop();
        }
        else
        {
            SnowWalk.loop = false;
            SnowWalk.Stop();
        }
        
    }
    
 


    
}