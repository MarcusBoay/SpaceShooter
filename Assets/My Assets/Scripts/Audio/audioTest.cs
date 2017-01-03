using UnityEngine;
using System.Collections;

public class audioTest : MonoBehaviour 
{
    public GameObject audioObject;

	void Start () 
	{
        audioObject.GetComponent<AudioSource>().Play();
        audioTestPlay(audioObject);
	}

    IEnumerator audioTestPlay(GameObject audioObject)
    {
        while (true)
        {
            audioObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2);
        }
    }
}
