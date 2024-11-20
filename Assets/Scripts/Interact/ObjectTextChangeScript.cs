using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectTextChangeScript : MonoBehaviour
{
    private TMP_Text text;
    private GameObject child;
    [SerializeField] private ObjectInfo objectInfo;


    private void Start()
    {
        child = transform.GetChild(0).gameObject;
        text = child.GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HLAO");
        if (collision.CompareTag("Player"))
        {
            text.text = objectInfo.popupText;
            child.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            child.SetActive(false);
        }
    }
}
