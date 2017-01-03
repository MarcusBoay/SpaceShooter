using UnityEngine;
using System.Collections;

public class BossShieldCollide : MonoBehaviour 
{
    public GameObject previousShield;
    public int maxHealth;
    public int curHealth;
    public GameObject explosion;
    public GameObject BossBody;

    void Start()
    {
        curHealth = maxHealth;
    }

	void Update () 
	{
        if (curHealth <= 0 && previousShield == null && BossBody.GetComponent<BossAI>().myBossState != BossAI.BossState.SPAWNING)
        {
            //destroys enemy gameobject when hp = 0
            Destroy(this.gameObject);
            gameObject.GetComponent<EnemyScore>().AddScore();
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet" && previousShield == null)
        {
            //deactivate player bullet on collision with enemy
            other.gameObject.SetActive(false);
            //set player bullet state to not active
            other.gameObject.GetComponent<PlayerBulletMovement>().myBulletState = PlayerBulletMovement.BulletState.NOTACTIVE;
            //damage enemy hp if and only if it is not in spawning state
            if (BossBody.GetComponent<BossAI>().myBossState != BossAI.BossState.SPAWNING)
            {
                curHealth = curHealth - other.gameObject.GetComponent<BulletDamage>().bulletDamage;
            }
        }
    }
}
