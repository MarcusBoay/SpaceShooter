using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    //temporary wave spawner
    public Vector3 spawnValues;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    List<GameObject> enemies = new List<GameObject>();
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameObject myCamera;

	void Start ()
    {
        enemies.Add(enemy1);
        enemies.Add(enemy2);
        enemies.Add(enemy3);
        enemies.Add(enemy4);
        StartCoroutine(SpawnWaves(enemies));
        myCamera = GameObject.Find("Main Camera").gameObject;
	}

    IEnumerator SpawnWaves(List<GameObject> enemies)
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int n = Random.Range(0, 4);
                Vector3 spawnPosition;
                //bad code lol, pls fix
                switch (n)
                {
                    case 0:
                        spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                        Instantiate(enemies[n], spawnPosition, Quaternion.identity);
                        break;
                    case 1:
                        spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(-spawnValues.y, 0), spawnValues.z);
                        Instantiate(enemies[n], spawnPosition, Quaternion.identity);
                        break;
                    case 2:
                        spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(0,spawnValues.y), spawnValues.z);
                        Instantiate(enemies[n], spawnPosition, Quaternion.identity);
                        break;
                    case 3:
                        spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                        Instantiate(enemies[n], spawnPosition, Quaternion.Euler(0, 0, 90));
                        break;
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
