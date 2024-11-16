using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class WordHolder: MonoBehaviour
{
    public static WordHolder instance;
    public int currIndex;
    public List<WordInfo> collectedWords;
    public event Action PowerWordListChangePerformed;
    private bool _isHidden = true;
    public bool _canChangeHiddenStatus = true;
    public bool _isInSelectionMode = false;
    [SerializeField] RectTransform _rectTransform; 
    [SerializeField] float leftPosX ,middlePOoX;
    [SerializeField] private float tweenDuration;
    [SerializeField] private GameObject selector;
    private WordInfo _lastSelectedWord;

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
        selector.SetActive(false);
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
        if (_isInSelectionMode)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isInSelectionMode = false;
                selector.SetActive(false);
                SelectWord();
                currIndex = 0;
                return;
            }
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currIndex == 0) return;
                currIndex--;
                selector.GetComponent<RectTransform>().DOAnchorPosY(GetPosition(currIndex).y,.2f);
            } else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currIndex == collectedWords.Count-1) return;
                currIndex++;
                selector.GetComponent<RectTransform>().DOAnchorPosY(GetPosition(currIndex).y, .2f);
            }
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
    public void SelectWord()
    {
        _lastSelectedWord = collectedWords[currIndex];
    }
    public void StartSelection()
    {
        selector.SetActive(true);
        selector.GetComponent<RectTransform>().anchoredPosition = GetPosition(currIndex);
        _isInSelectionMode = true;
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
    private Vector3 GetPosition(int i)
    {
        return new Vector3(0, -50 + (-100 * i), 0);
    }
}
