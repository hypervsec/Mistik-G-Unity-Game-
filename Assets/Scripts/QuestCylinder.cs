using System.Collections;
using UnityEngine;
using TMPro;

public class QuestCylinder : MonoBehaviour
{
    [Header("UI (Hierarchy'den seç)")]
    public TextMeshProUGUI infoText;   // HIERARCHY'DEKİ text
    [TextArea] public string message = "Görev başladı!";
    public float showSeconds = 10f;

    [Header("Next Cylinder (Hierarchy'den seç)")]
    public GameObject nextCylinder;

    [Header("Player Tag")]
    public string playerTag = "Player";

    bool triggered = false;
    Collider myCol;
    Renderer[] myRenderers;

    void Awake()
    {
        myCol = GetComponent<Collider>();
        myRenderers = GetComponentsInChildren<Renderer>(true);

        // Text başlangıçta kapalı
        if (infoText != null)
            infoText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;

        // 1️⃣ Bu silindiri kapat
        if (myCol != null) myCol.enabled = false;
        foreach (var r in myRenderers)
            r.enabled = false;

        // 2️⃣ Sonraki silindiri hemen aç
        if (nextCylinder != null)
            nextCylinder.SetActive(true);

        // 3️⃣ Inspector'dan seçilen text'i göster
        if (infoText != null)
        {
            infoText.text = message;
            infoText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterTime());
        }
    }

    IEnumerator HideTextAfterTime()
    {
        yield return new WaitForSeconds(showSeconds);

        if (infoText != null)
            infoText.gameObject.SetActive(false);
    }
}
