using UnityEngine;
using System.Collections;

public class PlayerBulletMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private GameObject player;
    public float offsetX;
    public float offsetY;
    public float speed;
    
    void Start()
    {
        player = GameObject.Find("Player");
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position + new Vector3(1, 0, 0) * offsetX + new Vector3(0, 1, 0) * offsetY;
        rb2d.velocity = new Vector3(1, 0, 0) * speed;
    }
}
