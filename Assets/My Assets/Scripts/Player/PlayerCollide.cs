using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour 
{
    public GameObject explosion;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "EnemyBullet" || other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
