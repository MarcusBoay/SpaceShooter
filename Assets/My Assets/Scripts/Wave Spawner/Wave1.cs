using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave1 : MonoBehaviour 
{
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public Vector3 spawnValues;
    public float enemyCount;
    public int waveCount;
    public GameObject nextWave;
    public List<GameObject> enemies = new List<GameObject>();
    // omg why does this exist, help
    private enum _ySpawn
    {
        UP,
        DOWN
    }
    private _ySpawn ySpawn = _ySpawn.UP;
    private int ySpawnModifier = 1;

    private GameObject myCamera;

	void Start () 
	{
        myCamera = GameObject.Find("Main Camera").gameObject;
        StartCoroutine(SpawnEnemies(enemies));
	}

    IEnumerator SpawnEnemies(List<GameObject> enemies)
    {
        yield return new WaitForSeconds(startWait);
        for (int j = 0; j < waveCount; j++)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, spawnValues.y * ySpawnModifier + myCamera.transform.position.y, spawnValues.z);
                int n;
                if (ySpawn == _ySpawn.UP)
                    n = 0;
                else
                    n = 1;
                Instantiate(enemies[n], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            ySpawnModifier = -ySpawnModifier;
            if (ySpawn == _ySpawn.UP)
                ySpawn = _ySpawn.DOWN;
            else
                ySpawn = _ySpawn.UP;
        }
        nextWave.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
