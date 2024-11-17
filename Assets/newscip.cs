using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class newscip : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void Awake()
    {
        _player.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.SetActive(true);
    }
}
