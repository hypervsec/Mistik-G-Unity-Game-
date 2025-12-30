using UnityEngine;

public class FloatingRotatingCylinder : MonoBehaviour
{
    [Header("Rotation")]
    public float rotationSpeed = 60f;   // Dönme hızı

    [Header("Floating")]
    public float floatSpeed = 2f;        // Yukarı aşağı hız
    public float floatHeight = 0.25f;    // Ne kadar yükselsin

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Y ekseninde dönme
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Yukarı - aşağı hareket (sinüs dalgası)
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
