using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text TimerText;
    public GameObject player;
    public GameObject WinCanvas;
    public Text WinTime;
    public GameObject Timer;
    public AudioSource audioSource;

    public void Start()
    {
        PlayerPrefs.SetInt("isWin", 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        Timer.SetActive(false);
        Win();
    }
    public void Win()
    {
        audioSource.Play();
        PlayerPrefs.SetInt("isWin", 1);
        
        // Pause the game.
        PlayerPrefs.SetFloat("SensX", 0f);
        PlayerPrefs.SetFloat("SensY", 0f);
        Time.timeScale = 0;

        // Load the Win Canvas.
        WinTime.text = TimerText.text;
        WinCanvas.SetActive(true);
    }
}
