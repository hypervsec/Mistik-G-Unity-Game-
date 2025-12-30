using UnityEngine;

public class FloatingTextTrigger : MonoBehaviour
{
    public UIFloatingTextSpawner spawner;
    public string message = "+1 Kürek Alındı";
    public string playerTag = "Player";

    bool used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag(playerTag)) return;

        used = true;
        spawner.ShowCenter(message);
    }
}
