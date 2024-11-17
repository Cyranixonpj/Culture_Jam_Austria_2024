using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class THEFriedaBarScript : MonoBehaviour
{
    [SerializeField] private GameObject darkness;
    [SerializeField] private GameObject textOne;
    [SerializeField] private GameObject textTwo;
    [SerializeField] private GameObject textThree;
    private void Start()
    {
        DialogueSystem.Instance.FriedaInBarTalkedTo += StartCutscene;
    }


    private void StartCutscene()
    {
        StartCoroutine(Sequence());
    }
    private IEnumerator Sequence()
    {
        yield return StartCoroutine(FadeIn(darkness, 1.5f));
        yield return StartCoroutine(FadeInText(textOne, 1.5f));
        yield return StartCoroutine(FadeInText(textTwo, 1.5f));
        yield return StartCoroutine(FadeInText(textThree, 1.5f));
        yield return StartCoroutine(FadeOutText(textOne, 1f));
        yield return StartCoroutine(FadeOutText(textTwo, 1f));
        yield return StartCoroutine(FadeOutText(textThree, 1f));
    }
    private IEnumerator FadeIn(GameObject gameObject, float duration)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = spriteRenderer.color;
            tmpColor.a = Mathf.Lerp(0, 1, progress);
            spriteRenderer.color = tmpColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(1);
    }
    private IEnumerator FadeInText(GameObject gameObject, float duration)
    {
        TMP_Text text = gameObject.GetComponent<TMP_Text>();
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = text.color;
            tmpColor.a = Mathf.Lerp(0, 1, progress);
            text.color = tmpColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(1f);

    }

    private IEnumerator FadeOutText(GameObject gameObject, float duration)
    {
        TMP_Text text = gameObject.GetComponent<TMP_Text>();
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = text.color;
            tmpColor.a = Mathf.Lerp(1, 0, progress);
            text.color = tmpColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(.3f);

    }
}
