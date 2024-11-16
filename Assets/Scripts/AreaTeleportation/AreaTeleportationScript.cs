using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TeleportDirection
{
    North,
    East,
    South,
    West
}
public class AreaTeleportationScript : MonoBehaviour
{
    [SerializeField] private AreaInfo areaInfo;
    [SerializeField] private GameObject camera;
    [SerializeField] private TeleportDirection direction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (direction)
            {
                case TeleportDirection.North:
                    collision.transform.position = areaInfo.PlayerNorthSpawnPos;
                    break;
                case TeleportDirection.East:
                    collision.transform.position = areaInfo.PlayerEastSpawnPos;
                    break;
                case TeleportDirection.South:
                    collision.transform.position = areaInfo.PlayerSouthSpawnPos;
                    break;
                case TeleportDirection.West:
                    collision.transform.position = areaInfo.PlayerWestSpawnPos;
                    break;


            }
            camera.transform.position = areaInfo.CameraPosition;
        }
    }
}
    