using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;
    public GameObject BC;
    public GameObject[] players;
    public GameObject User;
    public GameObject Effecter;
    public int chosenskill;
    // Start is called before the first frame update
    void Start()
    {
        Wheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        User = GameObject.FindWithTag("CPlayer");
    }
    public void UseSkill(int skill_ID)
    {
        switch (skill_ID)
        {
            case 1:
                Debug.Log("Skill 1");
                chosenskill = 1;
                break;
            case 2:
                Debug.Log("Skill 2");
                chosenskill = 2;
                break;
            case 3:
                Debug.Log("Skill 3");
                chosenskill = 3;
                break;
            case 4:
                Debug.Log("Skill 4");
                chosenskill = 4;
                break;
            case 5:
                Debug.Log("Skill 5");
                chosenskill = 5;
                break;
            case 6:
                Debug.Log("Skill 6");
                chosenskill = 6;
                break;
            case 7:
                Debug.Log("Skill 7");
                chosenskill = 7;
                break;
            case 8:
                Debug.Log("Skill 8");
                chosenskill = 8;
                break;
            default:
                break;
        }
        Wheel.SetActive(true);
    }
    void Laser()
    {

    }
    void Sleepy(GameObject player)
    {

    }
    void Healing(GameObject player)
    {

    }
    void Shield()
    {

    }
    void Sucking(GameObject player)
    {

    }
    void Speedy()
    {

    }
    void Gift()
    {

    }
    void Switching(GameObject player)
    {

    }

    public void ChooseEffecter(int i)
    {
        Effecter = players[i];
        switch (chosenskill)
        {
            case 1:
                Laser();
                break;
            case 2:
                Sleepy(Effecter);
                break;
            case 3:
                Healing(Effecter);
                break;
            case 4:
                Shield();
                break;
            case 5:
                Sucking(Effecter);
                break;
            case 6:
                Speedy();
                break;
            case 7:
                Gift();
                break;
            case 8:
                Switching(Effecter);
                break;
        }
        Wheel.SetActive(false);
        Effecter = null;
    }

    public void CancelUse()
    {
        chosenskill = 0;
        Wheel.SetActive(false);
    }
}
