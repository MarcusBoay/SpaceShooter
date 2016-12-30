using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour 
{
    public int playerLives;

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
