using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public Button ResumeButton;
    public Button RestartButton;
    public Button MenuButton;
    public Button OptionsButton;

    private bool isPaused = false;

    void Start()
    {
        ResumeButton.onClick.AddListener(delegate {
            PauseCanvas.SetActive(false);
            Resume();
        });

        RestartButton.onClick.AddListener(() => Restart());

        MenuButton.onClick.AddListener(() => MainMenu());

        OptionsButton.onClick.AddListener(() => Options());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                PauseCanvas.SetActive(false);
                isPaused = false;
                Resume();
            }
            else
            {
                PauseCanvas.SetActive(true);
                isPaused = true;
                Pause();
            }
        }
    }

    // Pauses the game, multiplying the Time by 0.
    public void Pause()
    {
        PlayerPrefs.SetFloat("SensX", 0f);
        PlayerPrefs.SetFloat("SensY", 0f);
        Time.timeScale = 0;
    }

    // Resumes the game, multiplying the Time by 1.
    public void Resume()
    {
        PlayerPrefs.SetFloat("SensX", 1.0f);
        PlayerPrefs.SetFloat("SensY", 1.0f);
        Time.timeScale = 1;
    }

    // Restarts the scene.
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Loads the main menu scene.
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    // Loads the Options scene.
    public void Options()
    {
        Resume();
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
}
