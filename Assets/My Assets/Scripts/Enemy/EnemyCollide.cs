using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour
{
    public int health;
    public GameObject explosion;

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
            StartCoroutine(BlinkOnHit());
        }
    }

    IEnumerator BlinkOnHit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
        yield return new WaitForSeconds(0.02f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
