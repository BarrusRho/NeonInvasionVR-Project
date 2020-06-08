using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Controller m_controller;

    public OVRInput.Button pauseButton;

    public bool isGamePaused = false;

    public TextMeshProUGUI scoreInfoText;

    public TextMeshProUGUI earthProbingInfoText;

    public int score = 0;

    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject gamePauseCanvas;

    public GameObject asteroidWarningCanvas;

    public GameObject difficultyWarningCanvas;

    public GameObject reloadLeftWarningCanvas;

    public GameObject reloadRightWarningCanvas;

    //[SerializeField]
    //private GameObject uiBot;

    [SerializeField]
    private float startPlayerHealth = 100f;

    [SerializeField]
    public float currentPlayerHealth;

    [SerializeField]
    private Image playerHealthBar;

    [SerializeField]
    private float startEarthHealth = 100f;

    [SerializeField]
    private float currentEarthHealth;

    [SerializeField]
    private Image earthHealthBar;

    private ProbeCounter probeCounter;

    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

        timeManager.enabled = true;

        scoreInfoText = GameObject.Find("ScoreInfo_Text").GetComponent<TextMeshProUGUI>();

        scoreInfoText.text = score.ToString();

        probeCounter = GameObject.Find("Probe_Counter").GetComponent<ProbeCounter>();

        earthProbingInfoText = GameObject.Find("EarthProbingInfo_Text").GetComponent<TextMeshProUGUI>();

        earthProbingInfoText.text = probeCounter.missedCubesCurrent.ToString();

        currentPlayerHealth = startPlayerHealth;

        currentEarthHealth = startEarthHealth;

        gameOverCanvas.SetActive(false);

        gamePauseCanvas.SetActive(false);

        asteroidWarningCanvas.SetActive(false);

        difficultyWarningCanvas.SetActive(false);

        reloadLeftWarningCanvas.SetActive(false);

        reloadRightWarningCanvas.SetActive(false);

    //uiBot.SetActive(true);

    isGamePaused = false;

        Time.timeScale = 1.0f;

        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        earthProbingInfoText.text = probeCounter.missedCubesCurrent.ToString();

        if (OVRInput.GetDown(pauseButton) && isGamePaused == false)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;

        timeManager.enabled = false;

        isGamePaused = true;

        AudioListener.pause = true;

        gamePauseCanvas.SetActive(true);
    }
    
    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;

        timeManager.enabled = true;

        isGamePaused = false;

        AudioListener.pause = false;

        gamePauseCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;

        timeManager.enabled = true;

        AudioListener.pause = false;

        isGamePaused = false;

        gamePauseCanvas.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_One");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncreaseScoreForSwords()
    {
        score++;

        scoreInfoText.text = score.ToString();
    }

    public void IncreaseScoreForBullets()
    {
        score = score + 1;

        scoreInfoText.text = score.ToString();
    }

    public void PlayerDamageFromEnemy()
    {
        currentPlayerHealth = currentPlayerHealth -5f;

        playerHealthBar.fillAmount = currentPlayerHealth / startPlayerHealth; 

        if (currentPlayerHealth <= 0)
        {
            GameOver();
        }
    }

    public void PlayerDamageFromWall()
    {
        currentPlayerHealth = currentPlayerHealth - 5f;

        playerHealthBar.fillAmount = currentPlayerHealth / startPlayerHealth;

        if (currentPlayerHealth <= 0)
        {
            GameOver();
        }
    }

    public void HealthPowerUp()
    {
        currentPlayerHealth = currentPlayerHealth + 5f;

        playerHealthBar.fillAmount = currentPlayerHealth / startPlayerHealth;                
    }

    public void EarthDamage()
    {
        currentEarthHealth = currentEarthHealth - 12.5f;

        earthHealthBar.fillAmount = currentEarthHealth / startEarthHealth;

        if (currentEarthHealth <= 0)
        {
            GameOver();
        }
    }

    public void AsteroidWarningEnable()
    {
        asteroidWarningCanvas.SetActive(true);        
    }

    public void AsteroidWarningDisable()
    {
        asteroidWarningCanvas.SetActive(false);
    }
    
    public void DifficultyWarningEnable()
    {
        difficultyWarningCanvas.SetActive(true);
    }

    public void DifficultyWarningDisable()
    {
        difficultyWarningCanvas.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;

        timeManager.enabled = false;

        isGamePaused = true;

        AudioListener.pause = true;

        gameOverCanvas.SetActive(true);

        //uiBot.SetActive(false);
    }

    public void ReloadLeftWarningEnable()
    {
        reloadLeftWarningCanvas.SetActive(true);
    }

    public void ReloadLeftWarningDisable()
    {
        reloadLeftWarningCanvas.SetActive(false);
    }

    public void ReloadRightWarningEnable ()
    {
        reloadRightWarningCanvas.SetActive(true);
    }

    public void ReloadRightWarningDisable()
    {
        reloadRightWarningCanvas.SetActive(false);
    }
}
