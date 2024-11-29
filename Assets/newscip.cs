using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class newscip : MonoBehaviour
{
    
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _video;
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audio;
    private VideoPlayer _vp;
    
    
    private void Awake()
    {

        _video.SetActive(false);
        _vp = _video.GetComponentInChildren<VideoPlayer>();
    }
    private void Start()
    {
        _vp.loopPointReached += StartCutscene;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.GetComponent<PlayerMovement>().enabled = false;
        audio.enabled = false;
        Destroy(_player);
        WordHolder.instance.enabled = false;
        _video.SetActive(true);
    }

    private void StartCutscene(VideoPlayer _vp)
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        yield return StartCoroutine(FadeInText(text, 1f));
        yield return StartCoroutine(FadeOutText(text, .5f));
        
        PlayerPrefs.SetInt("ShowCredits", 1);
        SceneManager.LoadScene(0);
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
        yield return new WaitForSeconds(2f);

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
        yield return new WaitForSeconds(1f);

    }

}

