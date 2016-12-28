using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour 
{
    //make coroutine to move up and down in the y direction depending on where the player is at
    //make sure to disable movement when player is ded
    private GameObject player;
    private GameObject myCamera;
    private Rigidbody2D rb2d;
    public GameObject shooters;
    public float spawnInSpeed;
    public float spawnInTime;
    public float betweenShootTime;
    public float moveTime;
    public float ySpeed;

	void Start () 
	{
        player = GameObject.Find("Main Camera").transform.FindChild("Player").gameObject;
        myCamera = GameObject.Find("Main Camera").gameObject;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

	void Update () 
	{
        if (player.gameObject == null)
        {
            Destroy(gameObject);
        }
        rb2d.MovePosition(new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, 0));
	}

    IEnumerator Move()
    {
        //move in from right of screen
        rb2d.velocity = new Vector3(spawnInSpeed, 0, 0);
        yield return new WaitForSeconds(spawnInTime);
        while (player.gameObject != null)
        {
            //stop for some time
            rb2d.velocity = new Vector3(0, 0, 0);
            Shoot();
            yield return new WaitForSeconds(betweenShootTime);
            //move up
            if (player.transform.position.y >= gameObject.transform.position.y)
            {
                rb2d.velocity = new Vector3(0, ySpeed, 0);
            }
            //move down
            else
            {
                rb2d.velocity = new Vector3(0, -ySpeed, 0);
            }
            yield return new WaitForSeconds(moveTime);
        }
    }
    //function to shoot
    void Shoot()
    {

    }
}
