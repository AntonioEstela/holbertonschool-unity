using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public GameObject player;
    public AudioClip grassFootSteps;
    public AudioClip rockFootSteps;
    public AudioClip impactGrassSFX;
    public AudioClip impactRockSFX;
    public AudioSource audioSourceRunning;
    public AudioSource audioSourceLanding;
    public AudioSource backgroundSource;

    public void Start()
    {
        if (SceneManager.GetActiveScene().isLoaded)
        {
            backgroundSource.Play();
        }
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("isWin") == 1)
        {
            backgroundSource.Stop();
        }
    }
    private void Step()
    {
        RaycastHit hit;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.tag == "Grass")
                {
                    audioSourceRunning.PlayOneShot(grassFootSteps);
                }

                if (hit.collider.tag == "Rock")
                {
                    audioSourceRunning.PlayOneShot(rockFootSteps);
                }
            }
        }
    }

    private void GroundImpact()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Grass")
                {
                    audioSourceLanding.PlayOneShot(impactGrassSFX);
                }

                if (hit.collider.tag == "Rock")
                {
                    audioSourceLanding.PlayOneShot(impactRockSFX);
                }
        }
    }
}
