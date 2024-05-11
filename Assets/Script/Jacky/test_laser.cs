using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test_laser : MonoBehaviour
{
    public AudioClip hurt;
    public AudioClip s_shield_b;

    public bool shot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            shot = false;
            GetComponent<Animator>().SetBool("shot", true);
            StartCoroutine(Coroutine());
        }
    }

    private System.Collections.IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().SetBool("shot", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInfo>().shielded)
        {
            other.GetComponent<PlayerInfo>().shielded = false;
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Laser Hit And Shield Breaks!";
            GameObject.FindWithTag("CharSound").GetComponent<AudioSource>().PlayOneShot(s_shield_b);
        }
        else
        {
            other.GetComponent<PlayerInfo>().HP -= 15;
            other.GetComponent<Animator>().SetBool("TakeDamage", true);
            GameObject.FindWithTag("CharSound").GetComponent<AudioSource>().PlayOneShot(hurt);
            StartCoroutine(HurtCoroutine(other));
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Laser Hit!";
        }
        
    }
    private System.Collections.IEnumerator HurtCoroutine(Collider2D other)
    {
        yield return new WaitForSeconds(1f);
        other.GetComponent<Animator>().SetBool("TakeDamage", false );
    }
}
