using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private float Y_ANGLE_MIN = -50.0f;
    private float Y_ANGLE_MAX = 0.0f;

    public  Transform lookAt;
    public Transform camTransform;
    private Camera mainCamera;
    public bool isInverted = false;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    public float sensX;
    public float sensY;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
            isInverted = true;

        else
            isInverted = false;

        camTransform = transform;
        mainCamera = Camera.main;
        PlayerPrefs.SetFloat("SensX", 1.0f);
        PlayerPrefs.SetFloat("SensY", 1.0f);
    }

    private void Update()
    {
        sensX = PlayerPrefs.GetFloat("SensX");
        sensY = PlayerPrefs.GetFloat("SensY");

        currentX += Input.GetAxis("Mouse X") * sensX;
        currentY += Input.GetAxis("Mouse Y") * sensY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        if (isInverted == true)
        {
            Y_ANGLE_MAX = 50.0f;
            Y_ANGLE_MIN = 0.0f;
        }
        if (isInverted == false)
        {
            Y_ANGLE_MAX = 0.0f;
            Y_ANGLE_MIN = -50.0f;
        }
    }

    // LateUpdate is called once per frame
    private void LateUpdate()
    {

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation =  Quaternion.Euler(isInverted == true ? currentY : -currentY, currentX, 0);


        camTransform.position = lookAt.position + rotation * direction;

        camTransform.LookAt(lookAt.position);
    }
}
