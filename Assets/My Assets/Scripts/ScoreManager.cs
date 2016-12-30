using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    public int score;
    public GameObject scoreKeeper;

    void Update()
    {
        SetScore();
    }

    void SetScore()
    {
        scoreKeeper.GetComponent<Text>().text = score.ToString();
    }
}
