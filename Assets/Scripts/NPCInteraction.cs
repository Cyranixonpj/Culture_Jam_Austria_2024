using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCInfo _NPCInfo;
    private List<NPCInteraction> _npcsInRange = new List<NPCInteraction>();

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _npcsInRange.Remove(this);
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

        if (_NPCInfo.NPCId == 1)
        {
            DialogueSystem.Instance._needAWord = true;
        }
        else
        {
            if (_NPCInfo.GivenWord != null) 
                WordHolder.instance.AddWord(_NPCInfo.GivenWord);
            DialogueSystem.Instance._needAWord = false;
        }

       
    }
}