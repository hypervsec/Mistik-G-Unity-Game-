using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public KeyCollectAnimation key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            key.Play();
            GetComponent<Collider>().enabled = false; // Tekrar tetiklenmesin
        }
    }
}
