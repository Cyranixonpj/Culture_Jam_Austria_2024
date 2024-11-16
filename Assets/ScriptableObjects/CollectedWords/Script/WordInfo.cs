using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordInfo", menuName = "WordInfo/NewWordInfo")]
public class WordInfo : ScriptableObject
{
    public int wordID;
    public string word;
}
