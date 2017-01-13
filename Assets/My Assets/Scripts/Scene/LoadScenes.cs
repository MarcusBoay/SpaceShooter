using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScenes : MonoBehaviour 
{

    public void StartGame()
    {
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(1);
    }

    public void StartScreen()
    {
        StartCoroutine(_StartScreen());
    }

    IEnumerator _StartScreen()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(0);
    }
}
