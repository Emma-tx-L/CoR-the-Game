using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    PlayerHealth playerHealth;

    GameObject player;

    public GameObject enemy;
    public float spawnTime = 3f;
    //public Transform[] spawnPoints;

    Transform spawnPoint;

    public float maxRangeX;
    public float maxRangeZ;
    public float minRangeX;
    public float minRangeZ;
    public float range;

    float x;
    float z;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    //void MoveSpawn()
    //{
    //    x = player.transform.position.x + range;
    //    z = player.transform.position.z + range;

    //    z = Random.Range(0f, 360f);

    //    spawnPoint.transform.position = spawnPoint.transform.position;
    //    spawnPoint.transform.rotation = Quaternion.Euler(0, z, 0);

    //    float spawnX = spawnPoint.transform.position.x;
    //    float spawnZ = spawnPoint.transform.position.z;


    //    if (spawnPoint.transform.position.x <= minRangeX)
    //    {
    //        spawnX = minRangeX;
    //    }
    //    else if (spawnPoint.transform.position.x >= maxRangeX)
    //    {
    //        spawnX = maxRangeX;
    //    }
    //    else if (spawnPoint.transform.position.z >= maxRangeZ)
    //    {
    //        spawnZ = maxRangeZ;
    //    }
    //    else if (spawnPoint.transform.position.z <= minRangeZ)
    //    {
    //        spawnZ = minRangeZ;
    //    }
    //}

        void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
