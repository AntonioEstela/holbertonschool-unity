
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

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        setGravity();

        playerJump();

        playerRotation();
        
        movePlayer = movePlayer * speed;

        player.Move(movePlayer * Time.deltaTime);


        // If the player falls under -30 it will reappear
        if (player.transform.position.y < -30)
            transform.position = new Vector3(0, 50, 0);

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

    void playerRotation()
    {
        // Get the angle that we need to rotate relativly to the camera
        float targetAngle = Mathf.Atan2(movePlayer.x, movePlayer.z) * Mathf.Rad2Deg;

        // Smoothing the rotation
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        // Rotate the player.
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
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
    }
}
