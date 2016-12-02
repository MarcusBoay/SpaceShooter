using UnityEngine;
using System.Collections;

public class PlayerBulletMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position;
        rb2d.velocity = new Vector3(1, 0, 0);
    }
}
