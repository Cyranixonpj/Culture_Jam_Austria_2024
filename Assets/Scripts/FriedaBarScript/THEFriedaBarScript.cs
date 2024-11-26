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
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    private PlayerMovement pm;
    private DrunkPlayerMovement dpm;
    [SerializeField] private GameObject amelia;
    private BoxCollider2D ameliaCollider;
    public void Start()
    {
        DialogueSystem.Instance.FriedaInBarTalkedTo += StartCutscene;
        pm = player.GetComponent<PlayerMovement>();
        dpm = player.GetComponent<DrunkPlayerMovement>();
        ameliaCollider = amelia.GetComponent<BoxCollider2D>();
    }


    private void StartCutscene()
    {
        ameliaCollider.enabled = false;
        StartCoroutine(Sequence());
    }
    private IEnumerator Sequence()
    {
        yield return StartCoroutine(FadeIn(darkness, 1.5f));
        pm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pm.enabled = false;
        yield return StartCoroutine(FadeInText(textOne, 1.5f));
        yield return StartCoroutine(FadeInText(textTwo, 1.5f));
        yield return StartCoroutine(FadeInText(textThree, 1.5f));
        yield return StartCoroutine(FadeOutText(textOne, 1f));
        yield return StartCoroutine(FadeOutText(textTwo, 1f));
        yield return StartCoroutine(FadeOutText(textThree, 1f));
        player.transform.position = new Vector3(7.6f, -32.41f, 0f);
        player.transform.localScale = new Vector3(2f, 2f, 0);
        camera.transform.position = new Vector3(0, -33.13f, -10f);
        dpm.enabled = true;
        Destroy(gameObject);
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
