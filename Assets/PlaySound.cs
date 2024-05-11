using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource AudioPlayer;
    public AudioClip[] AudioClips;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void click()
    {
        AudioPlayer.clip = AudioClips[0];
        AudioPlayer.Play();
    }
}
