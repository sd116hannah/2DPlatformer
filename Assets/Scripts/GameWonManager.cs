using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameWon");
    }
}
