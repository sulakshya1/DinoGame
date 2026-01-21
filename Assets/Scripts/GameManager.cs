using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; set; }

    public float initialGamespeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed {  get; private set; }

    public Player player;
    public Spawnner spawnner;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button exitButton;

    private float score;

    private void Start()
    {
        
        //NewGame();
    }

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        spawnner = FindFirstObjectByType<Spawnner>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsByType<Obstacle>(FindObjectsSortMode.None);
        foreach (Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        gameSpeed = initialGamespeed;
        score = 0f;
        enabled = true;
        player.gameObject.SetActive(true);
        spawnner.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        UpdateHighScore();
    }
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawnner.gameObject.SetActive(false);
        if (exitButton != null)
            exitButton.onClick.AddListener(() => Application.Quit());

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        UpdateHighScore();
    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }


    private void UpdateHighScore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        highScoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }
}
