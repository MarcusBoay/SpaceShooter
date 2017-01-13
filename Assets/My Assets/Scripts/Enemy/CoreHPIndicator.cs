using UnityEngine;
using System.Collections;
using System;

public class CoreHPIndicator : MonoBehaviour 
{
	void LateUpdate () 
	{
        float multiple = Convert.ToSingle(this.gameObject.GetComponent<BossShieldCollide>().curHealth) / Convert.ToSingle(this.gameObject.GetComponent<BossShieldCollide>().maxHealth);
        GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(1 * (1 - multiple), 1 * multiple, 1 * multiple, 1));
        //GetComponent<SpriteRenderer>().material.color = new Color(1 * (1 - multiple), 1 * multiple, 1 * multiple, 1);
    }
}
