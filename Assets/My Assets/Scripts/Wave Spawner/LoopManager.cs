using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoopManager : MonoBehaviour 
{
    public int loop;
    public Text loopValueUI;

	void Start () 
	{
        loop = 1;
	}

    void Update()
    {
        loopValueUI.text = loop.ToString();
    }
}
