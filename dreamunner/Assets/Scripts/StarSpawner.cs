using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnRangeX = 7.34f;

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnStar();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnStar()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}