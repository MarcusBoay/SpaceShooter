using UnityEngine;
using System.Collections;

public class Wave3 : MonoBehaviour 
{
    public float startWait;
    public Vector3 spawnValues;
    public float enemyCount;
    public int zRotation;
    public GameObject enemy;
    private GameObject myCamera;

    void Start()
    {
        myCamera = GameObject.Find("Main Camera").gameObject;
        StartCoroutine(SpawnEnemies(enemy));
    }

    IEnumerator SpawnEnemies(GameObject enemy)
    {
        yield return new WaitForSeconds(startWait);
        Vector3 spawnPosition = new Vector3(spawnValues.x + myCamera.transform.position.x, Random.Range(-spawnValues.y, spawnValues.y) + myCamera.transform.position.y, spawnValues.z);
        Instantiate(enemy, spawnPosition, Quaternion.Euler(transform.rotation.x, transform.rotation.y, zRotation));
        this.gameObject.SetActive(false);
    }
}
