using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour 
{
    public GameObject explosion;
    private GameObject pl;

    void Start()
    {
        pl = GameObject.Find("PlayerManager").gameObject;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "EnemyBullet" || other.tag == "Enemy" || other.tag == "BossBody")
        {
            if (this.tag == "Player")
            {
                pl.GetComponent<PlayerLives>().DecreasePlayerLives();
                pl.GetComponent<PlayerStateMachine>().myPlayerState = PlayerStateMachine.PlayerState.DEAD;
                Destroy(this.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }
}
