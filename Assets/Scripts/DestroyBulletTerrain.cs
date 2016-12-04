using UnityEngine;
using System.Collections;

public class DestroyBulletTerrain : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet" || other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }
    }
}
