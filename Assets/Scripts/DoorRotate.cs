using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public float rotateAngle = 90f;   // 👈 burayı -90 yapacağız
    public float rotateSpeed = 2f;

    private bool isOpen = false;
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation * Quaternion.Euler(0f, rotateAngle, 0f);
    }

    void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * rotateSpeed
            );
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
