using UnityEngine;
using System.Collections;

public class PitchShift : MonoBehaviour 
{
	void Start () 
	{
        GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
	}
}
