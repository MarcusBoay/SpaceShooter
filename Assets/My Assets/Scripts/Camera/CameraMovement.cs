using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    public float xSpeed;
    private Vector3 initialPos;
    public GameObject finalWave;
    public bool isMoving;

    void Start()
    {
        isMoving = true;
        initialPos = transform.position;
    }

    void Update()
    {
        if (finalWave.activeSelf || gameObject.transform.position.x > 50)
        {
            isMoving = false;
        }
        if (isMoving)
        {
            transform.position = new Vector3(xSpeed * Time.time, initialPos.y, initialPos.z);
        }
    }
}
