using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Button BackButton;
    public Button ApplyButton;
    public Toggle InvertY;

    void Start()
    {
        try
        {
            // Handles when the player loads the scene by setting the toggle according to the previous configuration.
            InvertY.isOn = PlayerPrefs.GetInt("isInverted") == 1 ? true : false;
        }
        catch (System.Exception)
        {
            throw;
        }

        BackButton.onClick.AddListener(() => Back());
        ApplyButton.onClick.AddListener(() => Apply());
    }
    public static void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void Apply()
    {
        int toggleOn = InvertY.isOn == true ? 1 : 0;
        PlayerPrefs.SetInt("isInverted", toggleOn);
    }

}
