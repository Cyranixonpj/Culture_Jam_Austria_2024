using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _maxTime = 1.5f;
    private float _currTime = 0f;

    private void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Color tmp = _text.color;
        tmp.a = 0f;
        _text.color = tmp;
        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn()
    {
        Color color = _text.color;
        while (_currTime <= .5f)
        {
            yield return null;
            _currTime += Time.deltaTime;
            color.a = 0f + Mathf.Clamp01(_currTime / .5f);
            _text.color = color;
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        Color color = _text.color;
        while (_currTime <= _maxTime)
        {
            yield return null;
            _currTime += Time.deltaTime;
            color.a = 1.0f - Mathf.Clamp01(_currTime / _maxTime);
            _text.color = color;
        }
        Destroy(gameObject);
    }
}
