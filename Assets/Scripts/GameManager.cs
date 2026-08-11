using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public int score = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (score > 10) OpenSceneWon();
    }

    public void AddScore()
    {
        score++; // score = score + 1
    }

    public void OpenSceneLose()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OpenSceneWon()
    {
        SceneManager.LoadScene("GameWon");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

