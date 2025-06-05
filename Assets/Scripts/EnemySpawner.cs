using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minX = -16f, maxX = 16f;
    public float minY = 1f, maxY = 15f;
    public float fixedZ = 32f;
    public float minSpawnTime = 1f, maxSpawnTime = 3f;

    private bool spawning = false;
    private Coroutine spawnCoroutine;

    public void StartSpawning()
    {
        if (!spawning)
        {
            spawning = true;
            spawnCoroutine = StartCoroutine(SpawnEnemyLoop());
        }
    }

    public void StopSpawning()
    {
        if (spawning)
        {
            spawning = false;
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (spawning)
        {
            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            fixedZ
        );
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}