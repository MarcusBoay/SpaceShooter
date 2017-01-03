using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour 
{
    public enum Mode
    {
        NORMAL,
        ENDLESS
    }
    public static Mode GameMode;
    private bool modeManagerExists;
    
    void Start()
    {
        if (!modeManagerExists)
        {
            modeManagerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void LoadNormalMode()
    {
        GameMode = Mode.NORMAL;
    }

    public void LoadEndlessMode()
    {
        GameMode = Mode.ENDLESS;
    }
}
