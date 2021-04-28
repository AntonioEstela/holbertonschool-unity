using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{    public void OpenLinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/antonio-jos%C3%A9-estela-7b2a64156/");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/Antonio__Estela");
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/AntonioEstela");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/antonioestela73/");
    }
}
