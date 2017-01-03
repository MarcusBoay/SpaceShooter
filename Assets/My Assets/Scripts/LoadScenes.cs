using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScenes : MonoBehaviour 
{

    public void LoadNormalMode()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadEndlessMode()
    {
        SceneManager.LoadScene(2);
    }
}
