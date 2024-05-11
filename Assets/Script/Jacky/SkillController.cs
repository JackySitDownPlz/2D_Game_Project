using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
    private bool laser_targetting;
    public RectTransform laser_target;
    public Camera cam;
    public RectTransform parent;
    public AudioClip s_laser;
    public AudioClip s_hypno;
    public AudioClip s_heal;
    public AudioClip s_shield;
    public AudioClip s_shield_b;
    public AudioClip s_suction;
    public AudioClip s_gift;
    public AudioClip s_tele;
    public AudioClip s_speedy;
    public AudioClip get;
    public AudioClip lose;
    // Start is called before the first frame update
    void Start()
    {
        Wheel.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        User = GameObject.FindWithTag("CPlayer");
        if (laser_targetting)
        {
            Vector2 anchoredPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parent,Input.mousePosition,cam,out anchoredPos);
            laser_target.anchoredPosition = anchoredPos;
            if (Input.GetMouseButtonDown(0))
            {
                laser_targetting = false;
                Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                laser_target.anchoredPosition = new Vector2(1500, 1500);
                StartCoroutine(LaserCoroutine(target + new Vector3(0, 0, 10)));
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[0] -= 1;
                Finished();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                laser_targetting = false;
                GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().laser = false;
                laser_target.anchoredPosition = new Vector2(1500,1500);
            }
        }
    }
    public void UseSkill(int skill_ID)
    {
        switch (skill_ID)
        {
            case 1:
                Debug.Log("Skill 1");
                chosenskill = 1;
                ChooseEffecter(-1);
                break;
            case 2:
                Debug.Log("Skill 2");
                chosenskill = 2;
                Wheel.SetActive(true);
                GameObject.FindWithTag("Selector").GetComponent<ButtonDisabler>().noself = true;
                break;
            case 3:
                Debug.Log("Skill 3");
                chosenskill = 3;
                Wheel.SetActive(true);
                GameObject.FindWithTag("Selector").GetComponent<ButtonDisabler>().noself = false;
                break;
            case 4:
                Debug.Log("Skill 4");
                chosenskill = 4;
                ChooseEffecter(-1);
                break;
            case 5:
                Debug.Log("Skill 5");
                chosenskill = 5;
                Wheel.SetActive(true);
                GameObject.FindWithTag("Selector").GetComponent<ButtonDisabler>().noself = true;
                break;
            case 6:
                Debug.Log("Skill 6");
                chosenskill = 6;
                ChooseEffecter(-1);
                break;
            case 7:
                Debug.Log("Skill 7");
                chosenskill = 7;
                ChooseEffecter(-1);
                break;
            case 8:
                Debug.Log("Skill 8");
                chosenskill = 8;
                Wheel.SetActive(true);
                GameObject.FindWithTag("Selector").GetComponent<ButtonDisabler>().noself = true;
                break;
            default:
                break;
        }

        
    }
    void Laser()
    {
        laser_targetting = true;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().laser = true;
    }
    void Sleepy(GameObject player)
    {
        if (player.GetComponent<PlayerInfo>().shielded)
        {
            player.GetComponent<PlayerInfo>().shielded = false;
            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[1] -= 1;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Selected Player Is Shielded And Attack Breaks The Shield Instead!";
            GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_shield_b);
        }
        else
        {
            player.GetComponent<PlayerInfo>().slept = true;
            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[1] -= 1;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Selected Player Falls Asleep!";
            GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_hypno);
        }
        Finished();


    }
    void Healing(GameObject player)
    {
        player.GetComponent<PlayerInfo>().HP += 20;
        GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[2] -= 1;
        GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Gains 20 HP!";
        GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_heal);
        Finished();
    }
    void Shield()
    {
        if (!GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().shielded)
        {
            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().shielded = true;
            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[3] -= 1;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Is Now Shielded!";
            GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_shield);
            Finished();
        }
        else
        {
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Already Shielded!";
        }
        
    }
    void Sucking(GameObject player)
    {
        float dist = Vector3.Distance(GameObject.FindWithTag("CPlayer").transform.position, player.transform.position);
        if (dist < 10)
        {
            if (player.GetComponent<PlayerInfo>().shielded)
            {
                player.GetComponent<PlayerInfo>().shielded = false;
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[4] -= 1;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Selected Player Is Shielded And Attack Breaks The Shield Instead!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_shield_b);
            }
            else
            {
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().catfood += Math.Clamp(player.GetComponent<PlayerInfo>().catfood, 0, 10);
                player.GetComponent<PlayerInfo>().catfood -= Math.Clamp(player.GetComponent<PlayerInfo>().catfood, 0, 10);
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[4] -= 1;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player sucks " + Math.Clamp(player.GetComponent<PlayerInfo>().catfood, 0, 10).ToString() + " catfood from Player P" + player.GetComponent<PlayerInfo>().playerID.ToString();
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_suction);
            }
            Finished();
        }
        else
        {
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Selected Player Is Too Far Away!";
        }
    }
    void Speedy()
    {
        GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().Speed = 2;
        GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[5] -= 1;
        GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Will Move x2 Distance In This Round!";
        GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_speedy);
        Finished();
    }
    void Gift()
    {
        int roll_res = UnityEngine.Random.Range(1, 10);
        int roll_res2;
        switch (roll_res)
        {
            case 1:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().Speed = 2;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Will Move x2 Distance In This Round!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_speedy);
                break;
            case 2:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().NSpeed = 2;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Will Move x0.5 Distance In This Round!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_speedy);
                break;
            case 3:
                roll_res2 = UnityEngine.Random.Range(10, 21);
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().catfood += roll_res2;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Gains "+ roll_res2.ToString() + " Catfood!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(get);
                break;
            case 4:
                roll_res2 = UnityEngine.Random.Range(5, 16);
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().catfood -= roll_res2;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player loses " + roll_res2.ToString() + " Catfood!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(lose);
                break;
            case 5:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().shielded = true;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Is Now Shielded!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_shield);
                break;
            case 6:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().HP += 10;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Gains 10 HP!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_heal);
                break;
            case 7:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().HP -= 20;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Is Executed By The God Of Death!";
                break;
            case 8:
                GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().slept = true;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Falls Asleep And Wasted The Turn!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_hypno);
                StartCoroutine(selfSleepCoroutine());                
                break;
            case 9:
                GameObject.FindWithTag("CPlayer").transform.position = new Vector3(-8.5f, 7f, -1f);
                GameObject.FindWithTag("CPlayer").GetComponent<CatController>().back_direction = 1;
                GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Random Box: Player Is Teleported Back To Starting Point!";
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_tele);
                break;

        }
        GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[6] -= 1;
        Finished();

    }
    void Switching(GameObject player)
    {
        if (player.GetComponent<PlayerInfo>().shielded)
        {
            player.GetComponent<PlayerInfo>().shielded = false;
            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[7] -= 1;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Selected Player Is Shielded And Attack Breaks The Shield Instead!";
            GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_shield_b);
        }
        else
        {
            Vector3 user_pos = GameObject.FindWithTag("CPlayer").transform.position;
            Vector3 effecter_pos = player.transform.position;
            int user_BD = GameObject.FindWithTag("CPlayer").GetComponent<CatController>().back_direction;
            int effecter_BD = player.GetComponent<CatController>().back_direction;

            GameObject.FindWithTag("CPlayer").transform.position = effecter_pos;
            player.transform.position = user_pos;
            GameObject.FindWithTag("CPlayer").GetComponent<CatController>().back_direction = effecter_BD;
            player.GetComponent<CatController>().back_direction = user_BD;

            GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().items[7] -= 1;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player switches position with Player P" + player.GetComponent<PlayerInfo>().playerID.ToString();
            GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_tele);
        }
        Finished();
    }

    public void ChooseEffecter(int i)
    {
        if (i < 0)
        {
            Effecter = new GameObject();
        }
        else
        {
            Effecter = players[i];
        }
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
        Debug.Log("pressed");
        
    }

    public void CancelUse()
    {
        chosenskill = 0;
        Wheel.SetActive(false);
    }

    private System.Collections.IEnumerator LaserCoroutine(Vector3 target)
    {
        Debug.Log(target);
        GameObject.FindWithTag("Laser").GetComponent<test_laser>().shot = true;
        GameObject.FindWithTag("Laser").transform.position = GameObject.FindWithTag("CPlayer").transform.position;
        GameObject.FindWithTag("Laser").transform.LookAt(target);
        GameObject.FindWithTag("Laser").transform.Rotate(new Vector3(0, -90, 0));
        GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(s_laser);
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().laser = false;
        GameObject.FindWithTag("Laser").transform.position = new Vector3(-41.5f, 37.4f, 0);
        GameObject.FindWithTag("Laser").transform.rotation = Quaternion.identity;
    }

    void Finished()
    {
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().alpha = 0f;
    }
    private System.Collections.IEnumerator selfSleepCoroutine()
    {
        yield return new WaitForSeconds(2f);
        GameObject.FindWithTag("TurnManager").GetComponent<TurnManager>().SwitchTurn();
    }
    
}
