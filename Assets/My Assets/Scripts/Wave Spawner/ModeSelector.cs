using UnityEngine;
using System.Collections;

public class ModeSelector : MonoBehaviour 
{
    public GameObject NWS;
    public GameObject EWS;
       
	void Start () 
	{
        try
        {
            switch (ModeManager.GameMode)
            {
                case (ModeManager.Mode.NORMAL):
                    {
                        NWS.SetActive(true);
                        break;
                    }
                case (ModeManager.Mode.ENDLESS):
                    {
                        EWS.SetActive(true);
                        break;
                    }
            }
        }
        catch {}
        GameStateMachine.myGameState = GameStateMachine.GameState.NORMALENEMY;
	}
}
