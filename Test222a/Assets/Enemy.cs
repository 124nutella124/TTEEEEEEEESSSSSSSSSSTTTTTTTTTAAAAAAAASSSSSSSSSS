using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string playerTag = "Player";
    public float moveSpeed = 3.0f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;

        if (player == null)
        {
            Debug.LogError("Player with tag '" + playerTag + "' not found.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            transform.Translate((player.position - transform.position).normalized * moveSpeed * Time.deltaTime);
        }
    }
}