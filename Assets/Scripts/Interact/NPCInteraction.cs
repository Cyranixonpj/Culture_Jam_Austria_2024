using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCInfo _NPCInfo;
    [SerializeField] private Material HighlightMaterial; // Material for highlight effect
    private List<NPCInteraction> _npcsInRange = new List<NPCInteraction>();
    private SpriteRenderer _spriteRenderer;
    private Material _originalMaterial;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _originalMaterial = _spriteRenderer.material; // Save the original material
            _spriteRenderer.material = new Material(_spriteRenderer.material); // Ensure unique material instance
        }
        else
        {
            Debug.LogError("SpriteRenderer is missing! Ensure this GameObject has a SpriteRenderer component.");
        }
    }

    void Update()
    {
        if (_npcsInRange.Count == 0) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;

        NPCInteraction closestNPC = GetClosestNPC();
        if (closestNPC != null)
        {
            closestNPC.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _npcsInRange.Add(this);
            EnableHighlight(); // Enable highlight when the player enters the range
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _npcsInRange.Remove(this);
            DisableHighlight(); // Disable highlight when the player leaves the range
        }
    }

    private NPCInteraction GetClosestNPC()
    {
        NPCInteraction closestNPC = null;
        float closestDistance = float.MaxValue;

        foreach (var npc in _npcsInRange)
        {
            float distance = Vector2.Distance(npc.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNPC = npc;
            }
        }

        return closestNPC;
    }

    public void Interact()
    {
        string[] dialog = _NPCInfo.lines;
        DialogueSystem.Instance.StartDialogue(dialog);
        if (_NPCInfo.GivenWord != null) 
            WordHolder.instance.AddWord(_NPCInfo.GivenWord);
    }

    private void EnableHighlight()
    {
        if (_spriteRenderer != null && HighlightMaterial != null)
        {
            Debug.Log("Highlight enabled.");
            _spriteRenderer.material = HighlightMaterial; // Switch to highlight material
            _spriteRenderer.material.SetFloat("_Highlight", 1); // Set highlight parameter
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
            _spriteRenderer.material.SetFloat("_Highlight", 0); // Reset highlight parameter
            _spriteRenderer.material = _originalMaterial; // Switch back to original material
        }
    }
}
