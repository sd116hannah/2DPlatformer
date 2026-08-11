using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
