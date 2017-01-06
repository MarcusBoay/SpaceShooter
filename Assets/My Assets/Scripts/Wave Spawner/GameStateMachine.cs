using UnityEngine;
using System.Collections;

public class GameStateMachine : MonoBehaviour 
{
    public enum GameState
    {
        STARTSCREEN,
        NORMALENEMY,
        BOSS,
        GAMEOVER,
        WIN
    }
    public static GameState myGameState;

    void Start()
    {
        myGameState = GameState.STARTSCREEN;
    }
    /*
	void Update () 
	{
        switch (myGameState)
        {
            case (GameState.STARTSCREEN):
                {
                    break;
                }
            case (GameState.NORMALENEMY):
                {
                    break;
                }
            case (GameState.BOSS):
                {
                    break;
                }
            case (GameState.GAMEOVER):
                {
                    break;
                }
            case (GameState.WIN):
                {
                    break;
                }
        }
	}*/
}
