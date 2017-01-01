using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour 
{
    public GameObject player;
    public GameObject dummyPlayer;
    private GameObject _dummyPlayer;
    private Rigidbody2D rb2d;
    private GameObject myCamera;
    public Vector3 spawnPosition;
    public float spawnInSpeed;
    public float offsetX;
    public enum PlayerState
    {
        SPAWNING1,
        SPAWNING2,
        ALIVE,
        DEAD
    }
    public PlayerState myPlayerState;

    void Start()
    {
        myCamera = GameObject.Find("Main Camera").gameObject;
    }

    void FixedUpdate()
    {
        switch (myPlayerState)
        {
            case (PlayerState.SPAWNING1):
                {
                    _dummyPlayer = Instantiate(dummyPlayer, spawnPosition + myCamera.transform.position, Quaternion.Euler(0, 0, 270)) as GameObject;
                    rb2d = _dummyPlayer.GetComponent<Rigidbody2D>();
                    myPlayerState = PlayerState.SPAWNING2;
                    break;
                }
            case (PlayerState.SPAWNING2):
                {
                    rb2d.MovePosition(new Vector2(spawnInSpeed + transform.position.x, myCamera.transform.position.y + rb2d.transform.position.y));
                    if (spawnInSpeed + transform.position.x <= myCamera.transform.position.x + offsetX)
                    {
                        //destroy dummy player
                        //instantiate player
                        //change player state to alive
                    }
                    break;
                }
            case (PlayerState.ALIVE):
                {
                    break;
                }
            case (PlayerState.DEAD):
                {
                    //wait for seconds before spawning player
                    //change state to spawning
                    break;
                }
        }

        
    }
}
