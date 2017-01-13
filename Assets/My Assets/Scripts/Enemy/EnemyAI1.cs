using UnityEngine;
using System.Collections;

public class EnemyAI1 : MonoBehaviour
{
    public float xSpeed;
    private float yPos;
    public float[] yAmplitude;//0.25
    private GameObject LM;
    private int _loop;
    public int maxLoop;

    void Start()
    {
        //translation
        yPos = transform.position.y;
        LM = GameObject.Find("LoopManager").gameObject;
        if (LM.GetComponent<LoopManager>().loop <= maxLoop)
        {
            _loop = LM.GetComponent<LoopManager>().loop;
        }
        else
        {
            _loop = maxLoop;
        }
        //_loop = 1; //for renderer blink testing purposes
        GetComponent<EnemyScore>().score *= _loop;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + xSpeed, yPos + Mathf.Sin(transform.position.x) * yAmplitude[_loop - 1], transform.position.z);
    }
    /*this method lags severely!!! (Why???)
	void FixedUpdate ()
    {
        //this will move the enemy in the negative x direction but on a sin wave in the y axis
        //rb2d.MovePosition(new Vector2(transform.position.x + xSpeed, yPos + Mathf.Sin(transform.position.x) * yAmplitude[_loop-1]));
        //
	}*/
}
