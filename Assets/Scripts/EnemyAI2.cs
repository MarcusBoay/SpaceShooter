using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour
{
    public float xSpeed;
    //makes the enemy move more in curve or less curved
    public float yCurveModifier;
    //makes the enemy move in positive surve or negative curve
    public int yDirectionModifier;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //enemy move in negative x direction, exponential in y direction
        rb2d.MovePosition(new Vector2(transform.position.x + xSpeed, yDirectionModifier * Mathf.Exp(yCurveModifier * transform.position.x)));
	}
}
