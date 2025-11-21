using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine.Audio;

public class ShieldPowerUp : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 4);

    } 

    public GameObject ShieldPrefab;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Instantiate(ShieldPrefab);  // Spawn Shield
            //search for audio and apply it without needing to add it to script
            FindObjectOfType<AudioManager>().Play("PowerUp");

            Destroy(gameObject);            // destroy shield Pick Up
        }
    }
}