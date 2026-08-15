using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player;
    public GameObject enemyShooter;
    public GameObject enemyPatroller;
    public GameObject ambs;
    public GameObject music;

    public AudioClip winSound;

    public GameObject winGroup;

    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        winGroup.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++; // score = score + 1

        if (score == 2)
        {
            MuteAudioMaster();

            SoundAPI.Instance.PlayOneShotSound(player, winSound, 0.6f);

            winGroup.SetActive(true);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MuteAudioMaster()
    {
        Destroy(enemyShooter);
        Destroy(enemyPatroller);
        Destroy(ambs);
        Destroy(music);
    }
}

