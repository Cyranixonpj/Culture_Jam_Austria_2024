using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaInfo", menuName = "AreaInfo/NewAreaInfo")]
public class AreaInfo : ScriptableObject 
{
    public int AreaID;
    public Vector3 CameraPosition;
    public Vector3 PlayerNorthSpawnPos;
    public Vector3 PlayerEastSpawnPos;
    public Vector3 PlayerSouthSpawnPos;
    public Vector3 PlayerWestSpawnPos;
}
