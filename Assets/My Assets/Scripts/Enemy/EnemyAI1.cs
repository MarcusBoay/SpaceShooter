using UnityEngine;
using System.Collections;

public class EnemyAI1 : MonoBehaviour
{
    public float xSpeed;
    private float yPos;
    private Rigidbody2D rb2d;
    public float[] yAmplitude;//0.25
    private GameObject LM;
    private int _loop;
    public int maxLoop;

    void Start()
    {
        //translation
        yPos = transform.position.y;
        //getting gameobject
        rb2d = GetComponent<Rigidbody2D>();
        LM = GameObject.Find("LoopManager").gameObject;
        _loop = LM.GetComponent<LoopManager>().loop;
    }

    void Update()
    {
        if (LM.GetComponent<LoopManager>().loop <= maxLoop)
        {
            _loop = LM.GetComponent<LoopManager>().loop;
        }
        else
        {
            _loop = maxLoop;
        }
        transform.position = new Vector3(transform.position.x + xSpeed, yPos + Mathf.Sin(transform.position.x) * yAmplitude[_loop - 1], transform.position.z);
    }
    /*Only use FixedUpdate IF AND ONLY IF the body is NON-KINEMATIC.
	void FixedUpdate ()
    {
        //this will move the enemy in the negative x direction but on a sin wave in the y axis
        //rb2d.MovePosition(new Vector2(transform.position.x + xSpeed, yPos + Mathf.Sin(transform.position.x) * yAmplitude[_loop-1]));
        //^above method lags severely
	}*/
}
