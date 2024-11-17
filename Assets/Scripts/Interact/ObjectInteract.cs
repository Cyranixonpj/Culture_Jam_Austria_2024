using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectInfo objectInfo;
    [SerializeField] private GameObject popup;
    private bool _inRange;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private ObjectInteract _ob;
    public void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ob = GetComponent<ObjectInteract>();
    }
    public void Start()
    {
        WordHolder.instance.PowerWordSelected += CheckIfCorrectWordSelected;
    }

    public void Update()
    {
        if (!_inRange) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        Interact();
    }
    public void Interact()
    {
        if (WordHolder.instance.collectedWords.Count <= 0)
        {
            var textObject = Instantiate(popup, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            textObject.GetComponentInChildren<TextMeshProUGUI>().text = "NO WORDS OWNED";
            return;
        }
        WordHolder.instance.StartSelection();
    }

    public void CheckIfCorrectWordSelected()
    {
        Debug.Log("Halo");
        if (WordHolder.instance._lastSelectedWord == objectInfo.requriedWord)
        {
            DisappearObject(1);
        }
        else
        {
            var textObject = Instantiate(popup, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            textObject.GetComponentInChildren<TextMeshProUGUI>().text = "WRONG WORD";
        }
    }
       
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        _inRange = true;
    }
}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = false;
        }
    }
    public void DisappearObject(float duration)
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
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

}
