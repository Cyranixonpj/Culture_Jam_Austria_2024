using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using DG.Tweening;

public class WordHolder: MonoBehaviour
{
    public static WordHolder instance;
    public int currIndex;
    public List<WordInfo> collectedWords;
    public event Action PowerWordListChangePerformed;
    private Vector3 hiddenPosition = new Vector3(-200,0,0);
    private Vector3 showPosition = new Vector3(200, 0, 0);
    private bool _isHidden = true;
    public bool _canChangeHiddenStatus = true;
    [SerializeField] RectTransform _rectTransform; 
    [SerializeField] float leftPosX ,middlePOoX;
    [SerializeField] private float tweenDuration;
    
    private void NotifyPowerWordListChangePerformed()
    {
        PowerWordListChangePerformed?.Invoke();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && _canChangeHiddenStatus)
            if (_isHidden)
            {
                ShowJournal();
            }
            else
            {
                HideJournal();  
            }
    }
    public void AddWord(WordInfo word)
    {
        if (collectedWords.Contains(word)) return;
        collectedWords.Add(word);
        NotifyPowerWordListChangePerformed();
    }
    public void RemoveWord(WordInfo word)
    {
        if(!collectedWords.Contains(word)) return;
        collectedWords.Remove(word);
        NotifyPowerWordListChangePerformed();
    }
    public int GetIndexOfWord(WordInfo word)
    {
        if (!collectedWords.Contains(word)) return 99;
        return collectedWords.IndexOf(word);
    }
    public void ShowJournal()
    {
        _rectTransform.DOAnchorPosX(middlePOoX, tweenDuration);
        _isHidden = false;
    }
    public void HideJournal()
    {
        _rectTransform.DOAnchorPosX(leftPosX, tweenDuration);
        _isHidden = true;
    }
}
