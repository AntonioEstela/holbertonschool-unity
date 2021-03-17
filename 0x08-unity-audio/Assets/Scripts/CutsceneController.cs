using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject MainCamera;
    public GameObject Player;
    public GameObject TimerCanvas;
    public GameObject CutsceneCamera;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            CutsceneCamera.SetActive(false);
            MainCamera.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = true;
            TimerCanvas.SetActive(true);
        }
    }
}
