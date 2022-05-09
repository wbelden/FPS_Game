using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public int totalDesiredEnemies = 7;
    public float spawnInterval = 3;
    public int enemiesCreated = 2;

    void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while(enemiesCreated < totalDesiredEnemies) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy() {
        GameObject enemy = Instantiate(enemyPrefab.gameObject, this.transform.position, this.transform.rotation);
        enemy.GetComponent<SpawnedEnemy>().player = player;
        enemiesCreated += 1;
    }
}
