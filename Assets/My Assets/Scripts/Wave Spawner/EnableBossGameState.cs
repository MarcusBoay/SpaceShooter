using UnityEngine;
using System.Collections;

public class EnableBossGameState : MonoBehaviour 
{
	void Start () 
	{
        if (GameStateMachine.myGameState != GameStateMachine.GameState.GAMEOVER)
        {
            GameStateMachine.myGameState = GameStateMachine.GameState.BOSS;
        }	
	}
}
