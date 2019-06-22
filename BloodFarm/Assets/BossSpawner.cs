using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossToSpawn;
    public Transform spawnLocation;
    public bool destroySpawner;

    public void SpawnBoss()
    {
        if (destroySpawner)
        {
            Instantiate(bossToSpawn, spawnLocation.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(bossToSpawn, spawnLocation.position, Quaternion.identity);
        }
    }
}
