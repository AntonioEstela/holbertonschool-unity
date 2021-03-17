using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public Button MenuButton;
    public Button NextButton;

    public void Start()
    {
        MenuButton.onClick.AddListener(() => MainMenu());
        NextButton.onClick.AddListener(() => Next());
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;

        if (indexScene > 0 && indexScene < 3)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(indexScene + 1);
        }

        else
            MainMenu();
    }
}
