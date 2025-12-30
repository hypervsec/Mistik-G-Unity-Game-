using UnityEngine;

public class SimpleCarMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 60f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enabled = false; // oyuncu binince açılacak
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // ileri - geri
        Vector3 move = transform.forward * v * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // sağ - sol dönüş
        Quaternion turn = Quaternion.Euler(0f, h * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}
