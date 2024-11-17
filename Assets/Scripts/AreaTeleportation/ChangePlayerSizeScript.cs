using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangePlayerSizeScript : MonoBehaviour
{
    [SerializeField] private bool _isInnEnterance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(_isInnEnterance) 
                collision.transform.localScale = new Vector3(2, 2, 0);
            else
                collision.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
    }
}
