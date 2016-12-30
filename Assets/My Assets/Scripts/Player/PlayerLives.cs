using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour 
{
    public int playerLives;
    public Image[] playerLifeImages;

    void Update()
    {
        SetPlayerLifeImages();
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

    //function to revive player
    
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
        }
    }
}
