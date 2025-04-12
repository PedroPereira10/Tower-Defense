using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform goalTarget;
    [SerializeField] private float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int index = Random.Range(0, spawnPoints.Length);
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
            enemy.GetComponent<EnemyAI>().SetTarget(goalTarget); // aqui usamos GetComponent
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
