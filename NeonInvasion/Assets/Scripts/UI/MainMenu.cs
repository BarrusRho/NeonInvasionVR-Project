using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject storyMenuCanvas;

    [SerializeField]
    private GameObject controlsMenuCanvas;

    [SerializeField]
    private GameObject creditsMenuCanvas;

    [SerializeField]
    private GameObject playMenuCanvas;

    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();

        HideStoryMenuPanel();

        HideControlsMenuPanel();

        HideCreditsMenuPanel();

        HidePlayMenuPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("Level One is loading...");

        SceneManager.LoadScene("Level_One");
    }

    public void ShowStoryMenuPanel()
    {
        storyMenuCanvas.SetActive(true);

        controlsMenuCanvas.SetActive(false);

        creditsMenuCanvas.SetActive(false);

        playMenuCanvas.SetActive(false);
    }

    public void HideStoryMenuPanel()
    {
        storyMenuCanvas.SetActive(false);
    }

    public void ShowControlsMenuPanel()
    {
        controlsMenuCanvas.SetActive(true);

        storyMenuCanvas.SetActive(false);

        creditsMenuCanvas.SetActive(false);

        playMenuCanvas.SetActive(false);
    }

    public void HideControlsMenuPanel()
    {
        controlsMenuCanvas.SetActive(false);
    }

    public void ShowCreditsMenuPanel()
    {
        creditsMenuCanvas.SetActive(true);

        storyMenuCanvas.SetActive(false);

        controlsMenuCanvas.SetActive(false);

        playMenuCanvas.SetActive(false);
    }

    public void HideCreditsMenuPanel()
    {
        creditsMenuCanvas.SetActive(false);
    }

    public void ShowPlayMenuPanel()
    {
        playMenuCanvas.SetActive(true);

        creditsMenuCanvas.SetActive(false);

        storyMenuCanvas.SetActive(false);

        controlsMenuCanvas.SetActive(false);
    }

    public void HidePlayMenuPanel()
    {
        playMenuCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;

        isGamePaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");

        Application.Quit();
    }
}
