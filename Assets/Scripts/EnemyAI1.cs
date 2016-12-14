using UnityEngine;
using System.Collections;

public class EnemyAI1 : MonoBehaviour
{
    public float xSpeed;
    private float yPos;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        yPos = transform.position.y;
    }
	
	void FixedUpdate ()
    {
        //this will move the enemy in the negative x direction but on a sin wave in the y axis
        rb2d.MovePosition(new Vector2(transform.position.x + xSpeed, yPos + Mathf.Sin(transform.position.x)));
	}


}
