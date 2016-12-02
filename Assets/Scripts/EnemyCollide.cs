using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour
{
    //IMPORTANT NOTE!: OnTriggerEnter2D =/= OnTriggerEnter !!! 2D physics =/= 3D physics!!! They are programmed as DIFFERENT!!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
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
