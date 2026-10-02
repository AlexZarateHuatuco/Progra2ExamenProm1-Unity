using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración del Spawn")]
    [Tooltip("Prefab del enemigo que se va a instanciar")]
    [SerializeField] private GameObject enemyPrefab;

    [Tooltip("Lista de puntos (GameObjects o Transforms) donde pueden aparecer los enemigos")]
    [SerializeField] private Transform[] spawnPoints;

    [Tooltip("Tiempo en segundos entre cada spawn")]
    [SerializeField] private float spawnInterval = 3f;

    [Tooltip("Límite máximo de enemigos activos simultáneamente (0 = infinito)")]
    [SerializeField] private int maxEnemies = 10;

    [Header("Radio de Dispersión")]
    [Tooltip("Radio alrededor del punto elegido donde pueden aparecer los enemigos")]
    [SerializeField] private float spawnRadius = 0f;

    private int currentEnemyCount = 0;

    private void Start()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("¡No has asignado ningún Spawn Point en el Inspector!", this);
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (maxEnemies == 0 || currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        if (selectedSpawnPoint == null) return;

        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0;

        Vector3 spawnPosition = selectedSpawnPoint.position + randomOffset;

        Instantiate(enemyPrefab, spawnPosition, selectedSpawnPoint.rotation);

        currentEnemyCount++;
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnPoints == null) return;

        Gizmos.color = Color.red;
        foreach (Transform point in spawnPoints)
        {
            if (point != null)
            {
                Gizmos.DrawWireSphere(point.position, spawnRadius > 0 ? spawnRadius : 0.5f);
            }
        }
    }
}