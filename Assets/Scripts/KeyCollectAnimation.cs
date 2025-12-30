using UnityEngine;

public class KeyCollectAnimation : MonoBehaviour
{
    public float moveUpSpeed = 1.5f;
    public float rotateSpeed = 180f;
    public float lifeTime = 1.5f;

    private bool playAnimation = false;
    private float timer;

    void Update()
    {
        if (!playAnimation) return;

        // Yukarı çık
        transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;

        // Dön
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        // Zaman say
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Play()
    {
        playAnimation = true;
    }
}
