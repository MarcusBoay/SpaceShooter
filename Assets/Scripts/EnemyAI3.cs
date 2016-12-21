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
        //if player is alive, find player gameobject
        try
        {
            player = GameObject.Find("Main Camera").transform.FindChild("Player").gameObject;
        }
        catch
        {
            //player iz ded, do nothing
        }
        //initializing
        yPos = transform.position.y;
        rb2d = GetComponent<Rigidbody2D>();
        myCamera = GameObject.Find("Main Camera").gameObject;
        //for bullets
        StartCoroutine(SpawnBullets());
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
            Instantiate(Bullet);
            yield return new WaitForSeconds(shootRate);
        }
    }
}
