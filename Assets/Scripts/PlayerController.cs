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
    public int numberOfMaxBullets;

    private GameObject myCamera;
    private GameObject myPlayerBullets;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myCamera = GameObject.Find("Main Camera").gameObject;
        myPlayerBullets = GameObject.Find("PlayerBullets").gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.76f + myCamera.transform.position.x, 8.85f + myCamera.transform.position.x), Mathf.Clamp(transform.position.y, -4.89f + myCamera.transform.position.y, 4.92f + myCamera.transform.position.y), transform.position.z);

        MakeBullet();
    }

    // Update is called once per frame for physics
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        //Debug.Log("hor" + moveHorizontal);
        //Debug.Log("ver" + moveVertical);
        rb2d.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;
    }

    public void MakeBullet()
    {
        //checks if space bar key is hit and if time between bullets is less or more than fire rate
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //finds a disabled bullet and activated it then breaks from loop
            for (int i = 0; i < numberOfMaxBullets; i++)
            {
                if (!myPlayerBullets.transform.GetChild(i).gameObject.activeSelf)
                {
                    //set bullet position to be infront of the player
                    myPlayerBullets.transform.GetChild(i).transform.position = transform.position + new Vector3(1, 0, 0) * myPlayerBullets.transform.GetChild(i).GetComponent<PlayerBulletMovement>().offsetX + new Vector3(0, 1, 0) * myPlayerBullets.transform.GetChild(i).GetComponent<PlayerBulletMovement>().offsetY;
                    //set bullet gameobject to be true
                    myPlayerBullets.transform.GetChild(i).gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
