using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pivot;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        if (xAxisClamp > 90.0)
        {
            xAxisClamp = 90.0f;
            mouseY = 0;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0)
        {
            xAxisClamp = -90.0f;
            mouseY = 0;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        pivot.Rotate(Vector3.up * mouseX);
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            //player.Rotate(Vector3.up * mouseX);
            player.rotation = pivot.rotation;
            pivot.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
