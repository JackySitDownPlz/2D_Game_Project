using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}