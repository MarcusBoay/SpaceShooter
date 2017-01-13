using UnityEngine;
using System.Collections;

public class ModeSelector : MonoBehaviour 
{
    public GameObject NWS;
    public GameObject EWS;
    public GameObject finalWave;
    private bool isFinalWaveSpawned;
       
	void Start () 
	{
        isFinalWaveSpawned = false;
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
