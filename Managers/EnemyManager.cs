using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    PlayerHealth playerHealth;

    GameObject player;

    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
