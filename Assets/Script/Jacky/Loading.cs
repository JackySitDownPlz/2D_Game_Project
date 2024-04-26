using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private System.Collections.IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("village_day");
    }
}