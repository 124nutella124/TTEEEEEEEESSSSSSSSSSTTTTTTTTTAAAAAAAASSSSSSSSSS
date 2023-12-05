using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDIE : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If the colliding object is the player, destroy the enemy
            Destroy(gameObject);
        }
    }
}
