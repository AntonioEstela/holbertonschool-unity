using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Button BackButton;
    public Button ApplyButton;
    public Toggle InvertY;
    public AudioMixer mixer;
    public Slider BGMSlider;
    public Slider SFXSlider;

    void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMvolume", 0.9f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXvolume", 0.9f);
        
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

    public void Update()
    {
        BGMSlider.onValueChanged.AddListener(delegate { SetBGMLevel(); });
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXLevel(); });
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

    public void SetBGMLevel()
    {
        float BGMvalue = BGMSlider.value;
        mixer.SetFloat("BGMvolume", Mathf.Log10(BGMvalue) * 20);
        PlayerPrefs.SetFloat("BGMvolume", BGMvalue);
    }
    public void SetSFXLevel()
    {
        float SFXvalue = SFXSlider.value;
        mixer.SetFloat("SFXvolume", Mathf.Log10(SFXvalue) * 20);
        PlayerPrefs.SetFloat("SFXvolume", SFXvalue);
    }

}
