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
}
