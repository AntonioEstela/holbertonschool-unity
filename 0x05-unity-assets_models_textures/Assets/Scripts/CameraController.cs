using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX =0.0f;

    public  Transform lookAt;
    public Transform camTransform;
    private Camera mainCamera;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    public float sensX = 1.0f;
    public float sensY = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        camTransform = transform;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensX;
        currentY += Input.GetAxis("Mouse Y") * sensY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    // LateUpdate is called once per frame
    private void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation =  Quaternion.Euler(-currentY, currentX, 0);


        camTransform.position = lookAt.position + rotation * direction;

        camTransform.LookAt(lookAt.position);
    }
}
