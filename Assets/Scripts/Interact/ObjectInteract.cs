using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private WordInfo requriedWord;
    [SerializeField] private GameObject popup;
    private bool _inRange;

    void Start()
    {
        WordHolder.instance.PowerWordSelected += CheckIfCorrectWordSelected;
    }

    void Update()
    {
        if (!_inRange) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        Interact();
    }
    public void Interact()
    {
        WordHolder.instance.StartSelection();
    }

    public void CheckIfCorrectWordSelected()
    {
        if (WordHolder.instance._lastSelectedWord == requriedWord)
            Debug.Log("Zniszczone");
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

}
