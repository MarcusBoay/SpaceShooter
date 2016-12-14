using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour
{
    public float xSpeed;
    //makes the enemy move more in curve or less curved
    private float yCurveModifier;
    //makes the enemy move in positive surve or negative curve
    public int yDirectionModifier;
    private float yPos;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        yPos = transform.position.y;
        yCurveModifier = Random.Range(-0.4f, -0.1f);
    }

    void FixedUpdate()
    {
        //enemy move in negative x direction, exponential in y direction
        rb2d.MovePosition(new Vector2(transform.position.x + xSpeed, yPos + yDirectionModifier * Mathf.Exp(yCurveModifier * transform.position.x)));
	}
}
