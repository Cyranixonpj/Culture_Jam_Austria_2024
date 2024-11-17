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
        _audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isInnEnterance)
        {
            collision.transform.localScale = new Vector3(2, 2, 0);
            _audioManager.setTavern();
        }
        else
        {
            collision.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            _audioManager.setOutsied();
        }
        _audioManager.PlayBackgroundMusic();
    }
}

