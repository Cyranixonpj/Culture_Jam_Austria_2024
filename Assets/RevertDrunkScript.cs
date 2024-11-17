using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertDrunkScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerMovement pm;
    private DrunkPlayerMovement dpm;

    public void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        dpm = player.GetComponent<DrunkPlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pm.enabled = true;
            dpm.enabled = false;
        }
    }
}
