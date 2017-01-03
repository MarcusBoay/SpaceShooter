using UnityEngine;
using System.Collections;

public class PlayerBulletMovement : MonoBehaviour
{

    public GameObject SFXPrefab;
    private Rigidbody2D rb2d;
    private GameObject player;
    public float offsetX;
    public float offsetY;
    public float speed;

    public enum BulletState
    {
        JUSTACTIVE,
        ALIVE,
        NOTACTIVE
    }
    public BulletState myBulletState;
    
    void Start()
    {
        //bullet's player reference
        player = GameObject.Find("Player");
        //bullet's rigid body reference
        rb2d = GetComponent<Rigidbody2D>();
        //when bullet is created, set state to JUST ACTIVE
        myBulletState = BulletState.JUSTACTIVE;
    }

    void Update()
    {
        //to reference the spawned player
        try
        {
            player = GameObject.Find("Player");
        }
        catch
        {}
        //bulet state machine
        switch (myBulletState)
        {
            case (BulletState.JUSTACTIVE):
                try
                {
                    //set bullet position to be infront of the player
                    transform.position = player.transform.position + new Vector3(1, 0, 0) * offsetX + new Vector3(0, 1, 0) * offsetY;
                    //set bullet x velocity
                    rb2d.velocity = new Vector3(1, 0, 0) * speed;
                    //set bullet state to alive
                    myBulletState = BulletState.ALIVE;
                    Instantiate(SFXPrefab);
                }
                catch
                {
                    gameObject.SetActive(false);
                    myBulletState = BulletState.NOTACTIVE;
                }
                break;
            case (BulletState.ALIVE):
                //nothing, bullet is alive until event happens
                break;
            case (BulletState.NOTACTIVE):
                //switch bullet state to JUST ACTIVE when it is just set active
                myBulletState = BulletState.JUSTACTIVE;
                break;
        }
    }
}
