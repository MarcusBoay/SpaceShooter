using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour 
{
    public GameObject playerPrefab;
    public GameObject dummyPlayer;
    private Rigidbody2D rb2d;
    private GameObject myCamera;
    private GameObject _player;
    public Vector3 spawnPosition;
    public float spawnInSpeed;
    public float offsetX;
    public float invincibleTime;
    public float respawnTime;
    public enum PlayerState
    {
        SPAWNING,
        ALIVE,
        DEAD,
        GAMEOVER
    }
    public PlayerState myPlayerState;

    void Start()
    {
        dummyPlayer = GameObject.Find("Main Camera").transform.FindChild("DummyPlayer").gameObject;
        myCamera = GameObject.Find("Main Camera").gameObject;
    }
    
    void FixedUpdate()
    {
        switch (myPlayerState)
        {
            case (PlayerState.SPAWNING):
                {
                    if (!dummyPlayer.activeSelf)
                    {
                        dummyPlayer.transform.position = new Vector3(myCamera.transform.position.x + spawnPosition.x, dummyPlayer.transform.position.y, dummyPlayer.transform.position.z);
                        dummyPlayer.SetActive(true);
                        dummyPlayer.GetComponent<AudioSource>().Play();
                    }
                    dummyPlayer.transform.position += new Vector3(spawnInSpeed, 0, 0);
                    if (dummyPlayer.transform.position.x >= myCamera.transform.position.x + offsetX)
                    {
                        dummyPlayer.SetActive(false);
                        dummyPlayer.transform.position = spawnPosition;
                        _player = Instantiate(playerPrefab, new Vector3(myCamera.transform.position.x + offsetX, myCamera.transform.position.y, 0), Quaternion.Euler(0, 0, 270)) as GameObject;
                        _player.transform.parent = myCamera.transform;
                        _player.name = "Player";
                        myPlayerState = PlayerState.ALIVE;
                        StartCoroutine(Invincibility(_player));
                    }
                    break;
                }
            case (PlayerState.ALIVE):
                {
                    break;
                }
            case (PlayerState.DEAD):
                {
                    StartCoroutine(Respawn());
                    break;
                }
            case (PlayerState.GAMEOVER):
                {
                    break;
                }
        }
    }
    
    IEnumerator Invincibility(GameObject player)
    {
        player.tag = "Respawn";
        player.GetComponent<SpriteRenderer>().color = new Color(1, 0.92f, 0.016f, 1);
        yield return new WaitForSeconds(invincibleTime);
        player.tag = "Player";
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        if(gameObject.GetComponent<PlayerLives>().playerLives < 0)
        {
            myPlayerState = PlayerState.GAMEOVER;
        }
        else
        {
            myPlayerState = PlayerState.SPAWNING;
        }
    }
}
