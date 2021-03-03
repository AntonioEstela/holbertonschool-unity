using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button Level01;
    public Button Level02;
    public Button Level03;

    public Button OptionsButton;
    public Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        Level01.onClick.AddListener(() => LevelSelect(1));
        Level02.onClick.AddListener(() => LevelSelect(2));
        Level03.onClick.AddListener(() => LevelSelect(3));
        OptionsButton.onClick.AddListener(() => Options());
        ExitButton.onClick.AddListener(() => ExitGame());
    }
    public void LevelSelect(int level)
    {
        if (level > 0 && level < 4)
            SceneManager.LoadScene(level);
    }

    public void Options()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
