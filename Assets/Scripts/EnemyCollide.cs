using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour
{
    public int health;

    void Update()
    {
        if (health <= 0)
        {
            //destroys enemy gameobject when hp = 0
            Destroy(this.gameObject);
        }
    }

    //IMPORTANT NOTE!: OnTriggerEnter2D =/= OnTriggerEnter !!! 2D physics =/= 3D physics!!! They are programmed as DIFFERENT!!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            //destroy bullet on collision with enemy
            Destroy(other.gameObject);
            //damage enemy hp
            health = health - other.gameObject.GetComponent<BulletDamage>().bulletDamage;
        }
    }

    //to kill player when he get too close >:(
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
