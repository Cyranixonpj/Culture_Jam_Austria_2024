using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjectNPC/NPCInfo", fileName = "NPCInfo")]
public class NPCInfo : ScriptableObject
{
    public int NPCId;
    public string[] lines;
    public string GivenWord;

}
