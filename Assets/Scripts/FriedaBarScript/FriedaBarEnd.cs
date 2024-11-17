using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriedaBarEnd : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject oldFrieda;
    [SerializeField] private GameObject camera;
    private PlayerMovement pm;


    public void Start()
    {
        DialogueSystem.Instance.FriedaEnd += StartCutscene;
        pm = player.GetComponent<PlayerMovement>();
    }
    private void StartCutscene()
    {
        StartCoroutine(Sequence());
    }
    private IEnumerator Sequence()
    {
        yield return StartCoroutine(FadeOut(background, 1f));
        
        yield return new WaitForSeconds(5f);
        Destroy(oldFrieda);
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
