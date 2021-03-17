using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip rolloverButton;

    void OnMouseEnter()
    {
        Debug.Log("Hover");
        audioSource.PlayOneShot(rolloverButton);
    }
}
