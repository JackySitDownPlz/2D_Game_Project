using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject current_player;
    private bool freelook;
    float horizontal;
    float vertical;
    public float CameraSpeed;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        freelook = false;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            freelookToggle();
        }
        if(freelook)
        {
            cam.orthographicSize = 10;
            transform.position = transform.position + new Vector3(horizontal*Time.deltaTime* CameraSpeed, vertical * Time.deltaTime* CameraSpeed, 0);
        }
        else
        {
            cam.orthographicSize = 8;
            transform.position = current_player.transform.position + new Vector3(0, 0, -10);
        }
        
    }
    void freelookToggle()
    {
        freelook = !freelook;
    }
}
