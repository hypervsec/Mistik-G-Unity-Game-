using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6f;
    Rigidbody rb;
    Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // A - D
        float z = Input.GetAxis("Vertical");   // W - S

        // Kameran�n y�nleri
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        // Y eksenini s�f�rla (yerden kopmas�n)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * z + right * x;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
