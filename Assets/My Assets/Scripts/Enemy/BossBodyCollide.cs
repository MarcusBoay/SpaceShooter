using UnityEngine;
using System.Collections;

public class BossBodyCollide : MonoBehaviour 
{

    public GameObject explosionSmall;
    public GameObject explosionBig;
    public float beforeExplosionsTime;
    public float betweenExplosionsTime;
    public int numberOfSmallExplosions;
    public Vector2 explosionRadius;

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

    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(beforeExplosionsTime);
        for (int i = 0; i < numberOfSmallExplosions; i++)
        {
            Vector3 explosionPosition = new Vector3(Random.Range(-explosionRadius.x, explosionRadius.x), Random.Range(-explosionRadius.y, explosionRadius.y), 0);
            Instantiate(explosionSmall, explosionPosition + transform.position, transform.rotation);
            yield return new WaitForSeconds(betweenExplosionsTime);
        }
        Destroy(gameObject);
        Instantiate(explosionBig, transform.position, transform.rotation);
    }
}
