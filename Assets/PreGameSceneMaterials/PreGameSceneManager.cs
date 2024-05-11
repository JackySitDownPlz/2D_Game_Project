using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameSceneManager : MonoBehaviour
{
    public string nextScene;

    public void changeScene()
    {
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(nextScene);
    }
}
