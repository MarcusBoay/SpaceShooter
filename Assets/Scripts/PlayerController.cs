using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    public float speed;
    private Rigidbody2D rb2d;

    public GameObject Bullet;
    public float fireRate;
    private float nextFire = 0.0f;

    private GameObject camera;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera").gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.76f + camera.transform.position.x, 8.85f + camera.transform.position.x), Mathf.Clamp(transform.position.y, -4.89f + camera.transform.position.y, 4.92f + camera.transform.position.y), transform.position.z);

        MakeBullet();
    }

    // Update is called once per frame for physics
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;
    }

    public void MakeBullet()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate<GameObject>(Bullet);
        }
    }
}
