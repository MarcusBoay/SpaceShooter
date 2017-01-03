using UnityEngine;
using System.Collections;

public class AudioDestroyer : MonoBehaviour 
{
    public float time;

	void Start () 
	{
        StartCoroutine(Destroy());
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
