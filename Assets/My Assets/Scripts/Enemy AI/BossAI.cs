using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour 
{
    //make coroutine to move up and down in the y direction depending on where the player is at
    //make sure to disable movement when player is ded
    private GameObject player;
    private GameObject myCamera;
    private Rigidbody2D rb2d;
    public GameObject core;
    public GameObject[] shooters;
    public GameObject bullet;
    public Vector3 bulletOffset;
    public Vector2 bulletSpeed;
    public float betweenShootTime;
    public float moveTime;
    public float spawnInSpeed;
    private float _spawnInSpeed;
    public float ySpeed;
    private float _ySpeed;
    public float offsetX;
    public BossState myBossState;
    public enum BossState
    {
        SPAWNING,
        ALIVE,
        DYING,
        DEAD
    }

    void Start () 
	{
        player = GameObject.Find("Main Camera").transform.FindChild("Player").gameObject;
        myCamera = GameObject.Find("Main Camera").gameObject;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        _ySpeed = 0;
        _spawnInSpeed = spawnInSpeed;
        myBossState = BossState.SPAWNING;
    }

	void FixedUpdate () 
	{
        if (player.gameObject == null)
        {
            Destroy(gameObject);
        }
        if (core == null && myBossState == BossState.ALIVE)
        {
            myBossState = BossState.DYING;
        }
        switch (myBossState)
        {
            case (BossState.SPAWNING):
                {
                    rb2d.MovePosition(new Vector2(_spawnInSpeed + transform.position.x, myCamera.transform.position.y + rb2d.transform.position.y));
                    if (_spawnInSpeed + transform.position.x <= myCamera.transform.position.x + offsetX)
                    {
                        myBossState = BossState.ALIVE;
                        StartCoroutine(Move());
                    }
                    break;
                }
            case (BossState.ALIVE):
                {
                    rb2d.MovePosition(new Vector2(myCamera.transform.position.x + offsetX, myCamera.transform.position.y + rb2d.transform.position.y + _ySpeed));
                    break;
                }
            case (BossState.DYING):
                {
                    StartCoroutine(gameObject.GetComponent<BossBodyCollide>().Explode());
                    myBossState = BossState.DEAD;
                    break;
                }
            case (BossState.DEAD):
                {
                    break;
                }
        }
    }

    IEnumerator Move()
    {
        while (player.gameObject != null && core != null)
        {
            //stop for some time
            _spawnInSpeed = 0;
            _ySpeed = 0;
            Shoot();
            yield return new WaitForSeconds(betweenShootTime);
            //move up
            if (player.transform.position.y >= gameObject.transform.position.y)
            {
                _ySpeed = ySpeed;
            }
            //move down
            else
            {
                _ySpeed = -ySpeed;
            }
            yield return new WaitForSeconds(moveTime);
        }
    }
    //function to shoot
    void Shoot()
    {
        for (int i = 0; i < shooters.Length; i++)
        {
            GameObject _bullet = Instantiate(bullet, shooters[i].transform.position + bulletOffset, transform.rotation) as GameObject;
            _bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed;
        }
    }
}
