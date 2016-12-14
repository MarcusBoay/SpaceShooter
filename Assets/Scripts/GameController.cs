using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Vector3 spawnValues;
    public GameObject enemy1;
    public GameObject enemy2;
    List<GameObject> enemies = new List<GameObject>();

	void Start () {
        enemies.Add(enemy1);
        enemies.Add(enemy2);
        SpawnWaves(enemies[Random.Range(0, 2)]);
	}

    void SpawnWaves(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
