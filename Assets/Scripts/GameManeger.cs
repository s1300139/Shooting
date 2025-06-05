using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI RuleText;
    public GameObject startButton;
    public TextMeshProUGUI timerText;
    public float gameTime = 30f;
    public TextMeshProUGUI scoreText;
    public float score = 0f;
    public AudioSource scoreAudio;
    public GameObject uiPanel;
    public TextMeshProUGUI finalscoreText;
    public GameObject restartButton;

    private float currentTime;
    private bool isGameRunning = false;

    void Start()
    {
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        finalscoreText.gameObject.SetActive(false);
        uiPanel.SetActive(true);
        RuleText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isGameRunning)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime, 0, gameTime);
            timerText.text = Mathf.CeilToInt(currentTime).ToString();

            if (currentTime <= 0f)
            {
                EndGame();
            }
        }
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = "Score\n" + score.ToString();

        if (scoreAudio != null)
        {
            scoreAudio.Play();
        }
    }

    public void StartGame()
    {
        uiPanel.SetActive(false);
        RuleText.gameObject.SetActive(false);
        startButton.SetActive(false);
        timerText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        currentTime = gameTime;
        isGameRunning = true;

        FindObjectOfType<EnemySpawner>().StartSpawning();
    }

    void EndGame()
    {
        finalscoreText.text = "Final Score\n" + score.ToString();
        isGameRunning = false;
        timerText.text = "0";

        FindObjectOfType<EnemySpawner>().StopSpawning();

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        uiPanel.SetActive(true);
        restartButton.SetActive(true);
        finalscoreText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
