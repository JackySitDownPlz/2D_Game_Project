using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sucking : MonoBehaviour
{
    public GameObject cam;

    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
    }
    
    public void show()
    {
        GetComponent<CanvasGroup>().alpha = 255f;
        cam.GetComponent<CameraController>().wide = true;


    }
    public void hide()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        cam.GetComponent<CameraController>().wide = false;
    }
}
