using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player ReSpawn");
            collision.gameObject.GetComponent<Player>().Respawn();
        }
    }
}
