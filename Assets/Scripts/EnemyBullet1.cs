using UnityEngine;
using System.Collections;

public class EnemyBullet1 : MonoBehaviour
{

    private GameObject player;
    private GameObject enemy;
    private Rigidbody2D rb2d;
    
	void Start ()
    {
        //to find player position, if player is ded, kill self
        try
        {
            player = GameObject.Find("Main Camera").transform.FindChild("Player").gameObject;
            transform.position = player.transform.position + new Vector3(1, 0, 0);
            rb2d = GetComponent<Rigidbody2D>();
        }
        catch
        {
            //player iz ded. kill self
            Destroy(gameObject);
        }
	}
	
	void FixedUpdate ()
    {
        //fix lol
        rb2d.velocity = new Vector3(1, 0, 0);
	}
}
