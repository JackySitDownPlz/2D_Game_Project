using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDescription : MonoBehaviour
{
    public GameObject DBackground;
    public GameObject[] Descriptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(int id)
    {
        DBackground.GetComponent<CanvasGroup>().alpha = 255f;
        Descriptions[id].GetComponent<CanvasGroup>().alpha = 255f;
    }

    public void Hide(int id)
    {
        DBackground.GetComponent<CanvasGroup>().alpha = 0f;
        Descriptions[id].GetComponent<CanvasGroup>().alpha = 0f;
    }
}
