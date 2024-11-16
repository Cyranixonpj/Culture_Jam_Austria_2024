using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTeleportationScript : MonoBehaviour
{
    [SerializeField] private Vector3Int newPlayerPosition;
    [SerializeField] private Vector3Int newCameraPosition;
    [SerializeField] private GameObject camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = newPlayerPosition;
            camera.transform.position = newCameraPosition;
        }
    }
}
