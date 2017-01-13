using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour 
{
    public int playerLives;
    private int maxPlayerLives;
    public Image[] playerLifeImages;

    void Start()
    {
        maxPlayerLives = 3;
    }

    void Update()
    {
        SetPlayerLifeImages();
        if (playerLives >= 4)
        {
            playerLives = maxPlayerLives;
        }
    }

    private void SetPlayerLifeImages()
    {
        try
        {
            for (int i = 0; i < playerLives; i++)
            {
                playerLifeImages[i].gameObject.SetActive(true);
            }
            for (int i = 2; i >= playerLives; i--)
            {
                playerLifeImages[i].gameObject.SetActive(false);
            }
        }
        catch
        {
            //no more images to set active
        }
    }
    
    public void DecreasePlayerLives()
    {
        playerLives -= 1;
        GameOver();
    }

    public void GameOver()
    {
        if (playerLives < 0)
        {
            Debug.Log("Game Over");
            //change game state machine to gameover
        }
    }
}
