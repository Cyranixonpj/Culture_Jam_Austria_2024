using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectInfo objectInfo;
    [SerializeField] private GameObject popup;
    [SerializeField] private Material highlightMaterial; // Material for highlight effect
    private bool _inRange;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private ObjectInteract _ob;
    private Material _originalMaterial; // Original material reference

    public void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ob = GetComponent<ObjectInteract>();
    }

    public void Start()
    {
        WordHolder.instance.PowerWordSelected += CheckIfCorrectWordSelected;

        // Ensure the SpriteRenderer's original material is saved
        if (_spriteRenderer != null)
        {
            _originalMaterial = _spriteRenderer.material;
            _spriteRenderer.material = new Material(_spriteRenderer.material); // Ensure unique material instance
        }
        else
        {
            Debug.LogError("SpriteRenderer is missing! Ensure this GameObject has a SpriteRenderer component.");
        }

        // Debug material setup
        if (highlightMaterial == null)
        {
            Debug.LogError("Highlight material is not set in the Inspector!");
        }
        else
        {
            Debug.Log("Highlight material is correctly set: " + highlightMaterial.name);
        }
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
        DisappearObject(1);
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
            EnableHighlight(); // Highlight the object when the player enters the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = false;
            DisableHighlight(); // Remove the highlight when the player exits the trigger
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
    }

    private void EnableHighlight()
    {
        if (_spriteRenderer != null && highlightMaterial != null)
        {
            Debug.Log("Highlight enabled.");
            _spriteRenderer.material = highlightMaterial; // Switch to highlight material
            _spriteRenderer.material.SetFloat("_Highlight", 1); // Enable highlight effect (if the shader supports it)
        }
        else
        {
            Debug.LogError("Highlight material or SpriteRenderer is not set!");
        }
    }

    private void DisableHighlight()
    {
        if (_spriteRenderer != null && _originalMaterial != null)
        {
            Debug.Log("Highlight disabled.");
            _spriteRenderer.material.SetFloat("_Highlight", 0); // Disable highlight effect
            _spriteRenderer.material = _originalMaterial; // Restore the original material
        }
    }
}
