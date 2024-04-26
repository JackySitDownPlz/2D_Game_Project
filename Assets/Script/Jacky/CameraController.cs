using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject current_player;
    private bool freelook;
    float horizontal;
    float vertical;
    public float CameraSpeed;
    public Camera cam;
    public GameObject[] UIButtons;
    public GameObject Inventory;
    private bool busy;
    
    // Start is called before the first frame update
    void Start()
    {
        busy = false;
        freelook = false;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!busy)
        {
            current_player = GameObject.FindWithTag("CPlayer");
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                freelookToggle();
            }
            if (freelook)
            {
                
                cam.orthographicSize = 10;
                transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * CameraSpeed, vertical * Time.deltaTime * CameraSpeed, 0);

            }
            else
            {
                
                if (current_player != null)
                {
                    cam.orthographicSize = 8;
                    transform.position = current_player.transform.position + new Vector3(0, 0, -10);
                }

            }
        }
        
        
    }
    void freelookToggle()
    {
        freelook = !freelook;
        if (freelook)
        {
            foreach (var button in UIButtons)
            {
                Color imageColor = button.GetComponent<Image>().color;
                imageColor.a = 0f;
                button.GetComponent<Image>().color = imageColor;
                button.GetComponent<Button>().interactable = false;
                Inventory.GetComponent<CanvasGroup>().alpha = 0f;
                Inventory.GetComponent<CanvasGroup>().interactable = false;
            }

        }
        else
        {
            foreach (var button in UIButtons)
            {
                Color imageColor = button.GetComponent<Image>().color;
                imageColor.a = 255f;
                button.GetComponent<Image>().color = imageColor;
                button.GetComponent<Button>().interactable = true;
                Inventory.GetComponent<CanvasGroup>().alpha = 255f;
                Inventory.GetComponent<CanvasGroup>().interactable = true;
            }
        }
    }
    void busytoggle()
    {
        busy = !busy;
    }
    void LookAt(GameObject GO)
    {
        transform.position = GO.transform.position + new Vector3(0, 0, -10);
    }

}
