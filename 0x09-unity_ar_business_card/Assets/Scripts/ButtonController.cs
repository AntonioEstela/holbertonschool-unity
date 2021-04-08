using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{    public void OpenLinkedIn()
    {
        Debug.Log("OPEN URl");
        Application.OpenURL("https://www.linkedin.com/in/antonio-jos%C3%A9-estela-7b2a64156/");
    }

    public void OpenTwitter()
    {
        Debug.Log("OPEN URl");
        Application.OpenURL("https://twitter.com/Antonio__Estela");
    }

    public void OpenGitHub()
    {
        Debug.Log("OPEN URl");
        Application.OpenURL("https://github.com/AntonioEstela");
    }

    public void SentEmail()
    {
        
    }
}
