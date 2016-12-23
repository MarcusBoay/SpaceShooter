using UnityEngine;
using System.Collections;

public class Wave2 : MonoBehaviour 
{
    public float startWait;
    public float spawnWait;
    public Vector3 spawnValues;
    public float enemyCount;
    public GameObject nextWave;
    public GameObject enemy;
    private GameObject myCamera;

    void Start () 
	{
        myCamera = GameObject.Find("Main Camera").gameObject;
        StartCoroutine(SpawnEnemies(enemy));
	}

	IEnumerator SpawnEnemies(GameObject enemy)
    {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(-spawnValues.y, spawnValues.y) + myCamera.transform.position.y, spawnValues.z);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
