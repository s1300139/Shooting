using UnityEngine;
using System.Collections;

public class Enemyspawner : MonoBehaviour
{
    public static Enemyspawner instance;

    public GameObject enemyPrefab;

    public float minX = -16f;
    public float maxX = 16f;
    public float minY = 1f;
    public float maxY = 15f;
    public float fixedZ = 32f;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private Coroutine spawnCoroutine;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartSpawning();  // ← これを呼ぶために、下にメソッドが必要
    }

    // ★★ ← これが抜けていたためエラーになっていた！
    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnEnemyLoop());
        }
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = fixedZ;

        Vector3 spawnPos = new Vector3(x, y, z);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
