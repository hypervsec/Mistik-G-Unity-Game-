using UnityEngine;

public class Joyhareket : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float x = moveJoystick.Horizontal;
        float z = moveJoystick.Vertical;

        Vector3 move = transform.forward * z + transform.right * x;
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
    }
}
