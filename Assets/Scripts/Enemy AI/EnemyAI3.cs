using UnityEngine;
using System.Collections;

public class EnemyAI3 : MonoBehaviour
{
    public float xSpeed;

    public float startShootWait;
    public float shootRate;
    public float offsetX;
    public float offsetY;
    public float bulletSpeed;

    private GameObject player;
    private Rigidbody2D rb2d;
    public GameObject Bullet;
    
	void Start ()
    {
        //initializing
        rb2d = GetComponent<Rigidbody2D>();
        //if player is alive, find player gameobject
        try
        {
            player = GameObject.Find("Main Camera").transform.FindChild("Player").gameObject;
            //for bullets
            StartCoroutine(SpawnBullets());
        }
        catch
        {
            //player iz ded, do nothing
        }
    }

	void FixedUpdate ()
    {
        //move enemy in  x direction
        rb2d.MovePosition(new Vector2(xSpeed + transform.position.x,transform.position.y));
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(startShootWait);
        while (true)
        {
            //check if player is alive, if player is alive, pew pew
            if (GameObject.Find("Main Camera").transform.FindChild("Player") != null)
            {
                //find vector from enemy to player
                Vector3 distToPlayer = player.transform.position - transform.position;
                //spawn point of bullet
                Vector3 startPoint = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);
                //instantiate bullet
                GameObject bullet = (GameObject)Instantiate(Bullet, startPoint, Quaternion.identity);
                //set velocity of bullet using unit vector of distance from enemy to player
                bullet.GetComponent<Rigidbody2D>().velocity = distToPlayer.normalized * bulletSpeed;
            }
            yield return new WaitForSeconds(shootRate);
        }
    }
}
