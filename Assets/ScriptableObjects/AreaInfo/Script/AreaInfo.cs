using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaInfo", menuName = "AreaInfo/NewAreaInfo")]
public class AreaInfo : ScriptableObject 
{
    public int AreaID;
    public Vector3Int CameraPosition;
    public Vector3Int PlayerNorthSpawnPos;
    public Vector3Int PlayerEastSpawnPos;
    public Vector3Int PlayerSouthSpawnPos;
    public Vector3Int PlayerWestSpawnPos;
}
