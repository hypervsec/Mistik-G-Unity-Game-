using UnityEngine;

public class Hareket : MonoBehaviour
{
    public float hiz = 5f;
    public float donusHizi = 200f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float ileri = Input.GetAxis("Vertical");     // W - S
        float saga = Input.GetAxis("Horizontal");   // A - D

        // Kapsülün baktığı yöne göre hareket
        Vector3 hareket =
            transform.forward * ileri +
            transform.right * saga;

        rb.velocity = new Vector3(
            hareket.x * hiz,
            rb.velocity.y,
            hareket.z * hiz
        );
    }
}
