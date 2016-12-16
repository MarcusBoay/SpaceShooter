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
    private int currentBulletIndex;

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
        rb2d.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;
    }

    public void MakeBullet()
    {
        //checks if space bar key is hit and if time between bullets is less or more than fire rate
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //lazy way to do indexing of bullets
            //fix this
            //maybe put them in a list? and check bullet if isActive or not?

            /*
            if (!myPlayerBullets.transform.GetChild(0).gameObject.activeSelf)
            {
                myPlayerBullets.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (!myPlayerBullets.transform.GetChild(1).gameObject.activeSelf)
            {
                myPlayerBullets.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (!myPlayerBullets.transform.GetChild(2).gameObject.activeSelf)
            {
                myPlayerBullets.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (!myPlayerBullets.transform.GetChild(3).gameObject.activeSelf)
            {
                myPlayerBullets.transform.GetChild(3).gameObject.SetActive(true);
            }*/
            
            myPlayerBullets.transform.GetChild(currentBulletIndex).gameObject.SetActive(true);
            currentBulletIndex += 1;
            if (currentBulletIndex > numberOfMaxBullets - 1)
            {
                currentBulletIndex = 0;
            }
        }
    }
}
