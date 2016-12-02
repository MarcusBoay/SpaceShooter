using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    public float speed;
    private Rigidbody2D rb2d;
    public GameObject Bullet;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;

        MakeBullet();
    }

    public void MakeBullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate<GameObject>(Bullet);
        }
    }
}
