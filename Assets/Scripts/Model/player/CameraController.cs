using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform follow;
    public Vector3 cam;
    private float yMin= 0.4f;
    private float yMax = 150f;


    void Update()
    {
        Vector3 position = transform.position;
        position.y = (follow.position.y + cam.y);
        if(position.y < yMin)
        {
            position.y = yMin;
        }
        if(position.y > yMax)
        {
            position.y = yMax;
        }
        transform.position = position;
    }
}
