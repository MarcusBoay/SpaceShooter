using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    public float[] speed;
    private float _speed;
    private int speedSwitch;
    private Rigidbody2D rb2d;
    private GameObject speedText;

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
        speedSwitch = 3;
        _speed = speed[speedSwitch];
        speedText = GameObject.Find("Canvas").transform.FindChild("SpeedValue").gameObject;
        InvokeRepeating("MakeBullet", 0.0001f, 0.0001f);
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.76f + myCamera.transform.position.x, 8.85f + myCamera.transform.position.x), Mathf.Clamp(transform.position.y, -4.89f + myCamera.transform.position.y, 4.92f + myCamera.transform.position.y), transform.position.z);
        
        ChangeMoveSpeed();
        _speed = speed[speedSwitch];
        speedText.GetComponent<Text>().text = _speed.ToString();
    }

    // Update is called once per frame for physics
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector3(moveHorizontal, moveVertical, 0) * _speed;
    }

    public void MakeBullet()
    {
        //checks if space bar key is hit and if time between bullets is less or more than fire rate
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire || Input.GetKey(KeyCode.Joystick1Button1) && Time.time > nextFire)
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

    public void ChangeMoveSpeed()
    {
        //decrease player move speed
        if (Input.GetKeyDown(KeyCode.Z) && speedSwitch > 0 || Input.GetKeyDown(KeyCode.Joystick1Button6) && speedSwitch > 0)
        {
            speedSwitch--;
        }
        //increase player move speed
        else if (Input.GetKeyDown(KeyCode.X) && speedSwitch < 7 || Input.GetKeyDown(KeyCode.Joystick1Button4) && speedSwitch < 7)
        {
            speedSwitch++;
        }
    }
}
