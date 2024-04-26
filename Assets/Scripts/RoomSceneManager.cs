using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using TMPro;

public class RoomSceneManager : MonoBehaviour
{
    [SerializeField]
    Button buttonStartGame;

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Minigame1_GameScene");
    }

    public void OnClickLeaveRoom()
    {
        SceneManager.LoadScene("StartScene");
    }
}
