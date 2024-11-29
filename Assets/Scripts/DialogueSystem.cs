using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using DG.Tweening.Plugins;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; private set; }

    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    private int index;
    private PlayerMovement _pl;
    public int _wordId;
    public event Action FriedaInBarTalkedTo;
    public event Action FriedaEnd;
    public bool dialogueActive = false;
    private bool _itsFrieda = false;
    private bool _itsEnd = false;


    private void NotifyFriedaInBarTalkedTo()
    {
        FriedaInBarTalkedTo?.Invoke();
    }
    private void NotifyFriedaEnd()
    {
        FriedaEnd?.Invoke();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
        dialogueText.text = string.Empty;
        _pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue(string[] newLines)
    {
        dialogueActive = true;
        _pl.GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
        _pl.enabled = false;
        _pl.GetComponent<Animator>().SetBool("MDown", false);
        _pl.GetComponent<Animator>().SetBool("MUp", false);
        _pl.GetComponent<Animator>().SetBool("MRight", false);
        _pl.MuteWalkSound(true);
        lines = newLines;
        index = 0;
        gameObject.SetActive(true);
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
        if (lines[lines.Length-1] == "Frieda: Come to my room in a few hours.")
            _itsFrieda = true;
        if (lines[lines.Length - 1] == "Frieda: If you help me, I might get you this precious permit out of his pocket. Do we have a deal?")
            _itsEnd = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }else
        {
            if (_itsFrieda)
            {
                NotifyFriedaInBarTalkedTo();
                _itsFrieda= false;
            }
            if (_itsEnd)
            {
                NotifyFriedaEnd();
                _itsEnd= false;
            }
            dialogueActive = false;
            _pl.enabled = true;
            _pl.GetComponent<Animator>().SetBool("MDown", false);
            _pl.GetComponent<Animator>().SetBool("MUp", false);
            _pl.GetComponent<Animator>().SetBool("MRight", false);
            _pl.MuteWalkSound(true);
            dialogueText.text = string.Empty;
            lines = new string[0]; 
            gameObject.SetActive(false);
        }
    }
    
    


  
}