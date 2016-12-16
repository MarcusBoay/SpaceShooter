using UnityEngine;
using System.Collections;

public class DestroyBulletTerrain : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            //set bullet gameobject to not active
            other.gameObject.SetActive(false);
            //set bullet gameobject state to NOTACTIVE
            other.gameObject.GetComponent<PlayerBulletMovement>().myBulletState = PlayerBulletMovement.BulletState.NOTACTIVE;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
