using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public FixedJoystick lookJoystick;
    public float sensitivity = 3f;

    float xRotation = 0f;

    public Transform playerBody;

    void Update()
    {
        float mouseX = lookJoystick.Horizontal * sensitivity;
        float mouseY = lookJoystick.Vertical * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
