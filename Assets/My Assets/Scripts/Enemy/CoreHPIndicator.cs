using UnityEngine;
using System.Collections;
using System;

public class CoreHPIndicator : MonoBehaviour 
{
	void Update () 
	{
        float multiple = Convert.ToSingle(this.gameObject.GetComponent<BossShieldCollide>().curHealth) / Convert.ToSingle(this.gameObject.GetComponent<BossShieldCollide>().maxHealth);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1 * (1 - multiple), 1 * multiple, 1 * multiple, 1);
	}
}
