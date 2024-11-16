using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCInfo _NPCInfo;
    private bool _inRange;
    private PlayerMovement _pl;
    // private NPCInfo _npcInfo;
    private DialogueSystem _dialogueSystem;
    


    void Start()
    {
        _pl = GetComponent<PlayerMovement>();
        _dialogueSystem = GetComponent<DialogueSystem>();
        // _NPCInfo = GetComponent<NPCInfo>();
    }


    void Update()
    {
        if (!_inRange) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        Interact();
        _pl.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = true;
        }
    }


    public void Interact()
    {

        string[] dialog = _NPCInfo.lines;
        _dialogueSystem.lines = dialog;
        _dialogueSystem.StartDialogue();

    }
}