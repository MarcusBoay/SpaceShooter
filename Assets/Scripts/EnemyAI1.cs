using UnityEngine;
using System.Collections;

public class EnemyAI1 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float xSpeed;
    
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        //this will move the enemy in the negative x direction but on a sin wave in the y axis
        transform.position = new Vector3(transform.position.x + xSpeed, Mathf.Sin(transform.position.x), 0);
	}


}
