using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("RoomScene");
        print("Started");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
