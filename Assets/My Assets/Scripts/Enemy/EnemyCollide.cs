using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour
{
    public int health;
    public GameObject explosion;
    public GameObject blinkAudio;

    void Update()
    {
        if (health <= 0)
        {
            //destroys enemy gameobject when hp = 0
            Destroy(this.gameObject);
            gameObject.GetComponent<EnemyScore>().AddScore();
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
    }

    //IMPORTANT NOTE!: OnTriggerEnter2D =/= OnTriggerEnter !!! 2D physics =/= 3D physics!!! They are programmed as DIFFERENT!!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            //deactivate player bullet on collision with enemy
            other.gameObject.SetActive(false);
            //set player bullet state to not active
            other.gameObject.GetComponent<PlayerBulletMovement>().myBulletState = PlayerBulletMovement.BulletState.NOTACTIVE;
            //damage enemy hp
            health = health - other.gameObject.GetComponent<BulletDamage>().bulletDamage;
            //blink on hit if enemy is not ded
            if (health > 0)
            {
                StartCoroutine(BlinkOnHit());
            }
        }
    }

    IEnumerator BlinkOnHit()
    {
        Instantiate(blinkAudio, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.02f);
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
    }
}
