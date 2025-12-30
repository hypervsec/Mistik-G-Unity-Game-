using UnityEngine;

public class UIFloatingTextSpawner : MonoBehaviour
{
    public Canvas canvas;
    public FloatingUIText floatingPrefab;

    public void ShowCenter(string message)
    {
        FloatingUIText ui =
            Instantiate(floatingPrefab, canvas.transform);

        RectTransform rt = ui.GetComponent<RectTransform>();
        rt.anchorMin = rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = Vector2.zero;

        ui.Play(message);
    }
}
