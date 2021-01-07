using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 50;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text healthText;
    public Text scoreText;
    public GameObject winLose;
    public Image winLoseImg;
    public Text winLoseText;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // This will load the main menu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (health == 0)
        {
            winLoseText.text = "Game Over!";
            winLoseText.color = new Color(1, 1, 1, 1);
            winLoseImg.color = new Color(1, 0, 0, 1);
            winLose.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }
    void FixedUpdate()
    {
        float XInput = Input.GetAxis("Horizontal");
        float ZInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (XInput, 0.0f, ZInput);
        
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            winLose.SetActive(true);
            winLoseText.text = "You Win!";
            winLoseText.color = new Color(0, 0, 0, 1);
            winLoseImg.color = new Color(0, 1, 0);
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health.ToString()}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
