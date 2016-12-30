using UnityEngine;
using System.Collections;

public class EnemyScore : MonoBehaviour 
{
    public int score;
    private GameObject SM;

	void Start () 
	{
        SM = GameObject.Find("ScoreManager").gameObject;
	}

    public void AddScore()
    {
        SM.GetComponent<ScoreManager>().score += score;
    }
}
