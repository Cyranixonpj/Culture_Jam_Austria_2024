using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangePlayerSizeScript : MonoBehaviour
{
    [SerializeField] private bool _isInnEnterance;
    private AudioManager _audioManager;
    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isInnEnterance)
            {
                collision.transform.localScale = new Vector3(2, 2, 0);
                _audioManager.setOutsied();
            }
            else
            {
                collision.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                _audioManager.setTavern();
            }
            _audioManager.PlayBackgroundMusic();
                
        }
    }
}

