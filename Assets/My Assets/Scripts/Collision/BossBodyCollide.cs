using UnityEngine;
using System.Collections;

public class BossBodyCollide : MonoBehaviour 
{

    public GameObject explosion;
    //make coroutine to explode multiple times when core is ded
    public GameObject core;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            //deactivate player bullet on collision with enemy
            other.gameObject.SetActive(false);
            //set player bullet state to not active
            other.gameObject.GetComponent<PlayerBulletMovement>().myBulletState = PlayerBulletMovement.BulletState.NOTACTIVE;
        }
    }
}
