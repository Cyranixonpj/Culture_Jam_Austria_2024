using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class DisplayCollectedPowerWordsScript : MonoBehaviour
{
    [SerializeField] private GameObject wordHolderPrefab;
    private List<GameObject> displayedWords;
    [SerializeField] private int yStart;
    [SerializeField] private int ySpaceBetweenItems;

    private void Start()
    {
        displayedWords = new List<GameObject>();
        WordHolder.instance.PowerWordListChangePerformed += UpdateWordDisplay;
    }
    private void UpdateWordDisplay()
    {
        int i = 0;
        if(displayedWords.Count > 0) 
            foreach (var word in displayedWords)
            {
                Destroy(word);
            }
        foreach (var word in WordHolder.instance.collectedWords)
        {
            var wordHolder = Instantiate(wordHolderPrefab,transform);
            wordHolder.GetComponent<RectTransform>().anchoredPosition = GetPosition(i);
            wordHolder.GetComponentInChildren<TextMeshProUGUI>().text = word.word;
            displayedWords.Add(wordHolder);
            i++;
        }
    }
    private Vector3 GetPosition(int i)
    {
        return new Vector3(0, yStart + (-ySpaceBetweenItems * i), 0);
    }
}
