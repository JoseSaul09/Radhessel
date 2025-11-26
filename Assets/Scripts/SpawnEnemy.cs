using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnpoints;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;

    private int currentEnemyCount = 0;

    private void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab no asignado en SpawnEnemy!");
            return;
        }

        if (spawnpoints.Length == 0)
        {
            Debug.LogError("No hay spawn points asignados en SpawnEnemy!");
            return;
        }

        InvokeRepeating("SpawnEnemies", spawnInterval, spawnInterval);
    }

    void SpawnEnemies()
    {
        if (currentEnemyCount < maxEnemies)
        {
            int randomIndex = Random.Range(0, spawnpoints.Length);
            Transform spawnPoint = spawnpoints[randomIndex];

            if (enemyPrefab != null)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                currentEnemyCount++;

                // Si quieres, puedes subscribirte a un evento para disminuir currentEnemyCount cuando muera
                EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
                if (eh != null)
                {
                    eh.onDeath += () => currentEnemyCount--;
                }
            }
        }
    }
}
