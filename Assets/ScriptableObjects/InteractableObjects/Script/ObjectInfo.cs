using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectInfo", menuName = "ObjectInfo/NewObjectInfo")]
public class ObjectInfo : ScriptableObject
{
    public int objectID;
    public WordInfo requriedWord;
    public string popupText;

}
