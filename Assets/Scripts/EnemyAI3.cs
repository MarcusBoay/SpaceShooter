using UnityEngine;
using System.Collections;

public class EnemyAI3 : MonoBehaviour
{

    public float xSpeed;
    private float yPos;
    public float startShootWait;
    public float shootRate;

    private GameObject player;
    private Rigidbody2D rb2d;
    public GameObject Bullet;
    private GameObject myCamera;
    
	void Start ()
    {
        //initializing
        yPos = transform.position.y;
        rb2d = GetComponent<Rigidbody2D>();
        myCamera = GameObject.Find("Main Camera").gameObject;
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
                Instantiate(Bullet);
            }
            yield return new WaitForSeconds(shootRate);
        }
    }
}
