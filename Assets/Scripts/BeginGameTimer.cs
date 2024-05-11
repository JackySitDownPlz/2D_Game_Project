using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGameTimer : MonoBehaviour
{
    public int timer = 3;
    public Text beginGameText;
    public string nextScene;

    void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while (timer > 0)
        {
            beginGameText.text = timer.ToString();

            yield return new WaitForSeconds(1f);

            timer--;
        }

        beginGameText.text = "GO!";

        StartCoroutine(changeScene(nextScene));
    }

    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
