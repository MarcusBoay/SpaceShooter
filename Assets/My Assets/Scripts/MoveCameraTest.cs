using UnityEngine;
using System.Collections;

public class MoveCameraTest : MonoBehaviour {

    public float xSpeed;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }
	
	void Update () {
        transform.position = new Vector3(xSpeed * Time.time, initialPos.y, initialPos.z);
	}
}
