using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FriedaBarEnd : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject oldFrieda;
    [SerializeField] private GameObject oldNewspaperGuy;
    [SerializeField] private GameObject oldAmelia;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject snowOne;
    [SerializeField] private GameObject snowTwo;
    [SerializeField] private GameObject snowThree;
    [SerializeField] private GameObject newSnow;
    [SerializeField] private GameObject lightObject;
    [SerializeField] private GameObject amelia;
    private BoxCollider2D ameliaCollider;
    private PlayerMovement pm;
    private Light2D light;


    public void Start()
    {
        light = lightObject.GetComponent<Light2D>();
        DialogueSystem.Instance.FriedaEnd += StartCutscene;
        pm = player.GetComponent<PlayerMovement>();
        ameliaCollider = amelia.GetComponent<BoxCollider2D>();
    }
    private void StartCutscene()
    {
        ameliaCollider.enabled = false;
        StartCoroutine(Sequence());
    }
    private IEnumerator Sequence()
    {
        yield return StartCoroutine(FadeOut(background, 1f));
        yield return new WaitForSeconds(5f);
        Destroy(oldFrieda);
        Destroy(oldNewspaperGuy);
        Destroy(oldAmelia);
        Instantiate(newSnow, snowOne.transform.position, Quaternion.identity);
        Instantiate(newSnow, snowTwo.transform.position, Quaternion.identity);
        Instantiate(newSnow, snowThree.transform.position, Quaternion.identity);
        Destroy(snowOne);
        Destroy(snowTwo);
        Destroy(snowThree);
        light.color = new Color32(4,4,4,255);
        player.transform.position = new Vector3(3f, -17.36f, 0f);
        player.transform.localScale = new Vector3(2f, 2f, 0);
        camera.transform.position = new Vector3(0, -16.616f, -10f);
    }
    private IEnumerator FadeOut(GameObject gameObject, float duration)
    {
        float startAlpha = gameObject.GetComponent<SpriteRenderer>().color.a;
        SpriteRenderer text = gameObject.GetComponent<SpriteRenderer>();
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = text.color;
            tmpColor.a = Mathf.Lerp(startAlpha, 1, progress);
            text.color = tmpColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(.3f);

    }
}
