using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 playerInput;
    public CharacterController player;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float speed = 14f;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    private float fallVelocity;
    public float jumpForce = 3.7f;
    public  Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        player.transform.LookAt(player.transform.position + movePlayer);
        setGravity();

        playerJump();
        
        movePlayer = movePlayer * speed;

        player.Move(movePlayer * Time.deltaTime);


        // If the player falls under -30 it will reappear
        if (player.transform.position.y < -30)
            transform.position = new Vector3(0, 100, 0);

        if (player.transform.position.y < -10)
        {
            animator.SetBool("isFalling", true);
        }
        else if(player.isGrounded)
        {
            animator.SetBool("isFalling", false);
        }

        if (playerInput != Vector3.zero)
        {
            animator.SetBool("isRuning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isRuning", false);
            animator.SetBool("isIdle", true);
        }
    }

    // Movement relative to the camera
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    // Setting up gravity
    void setGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    // Handle Player Jump
    void playerJump()
    {
        if (player.isGrounded && Input.GetButton("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("isJumping");
        }
    }
}
