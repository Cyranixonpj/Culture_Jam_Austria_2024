using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDisapear : MonoBehaviour
{
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private ObjectInteract _ob;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ob = GetComponent<ObjectInteract>();
    }

    private void Update()
    {
        if (_ob.goodWord == true)
        {
            DisappearTree(1);
        }
    }

    public void DisappearTree(float duration)
    {
        StartCoroutine(FadeOutAndDisableCollider(duration));
    }

    private IEnumerator FadeOutAndDisableCollider(float duration)
    {
        float startAlpha = _spriteRenderer.color.a;
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = _spriteRenderer.color;
            tmpColor.a = Mathf.Lerp(startAlpha, 0, progress);
            _spriteRenderer.color = tmpColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }

        _collider.enabled = false;
        gameObject.SetActive(false);
    }
}
