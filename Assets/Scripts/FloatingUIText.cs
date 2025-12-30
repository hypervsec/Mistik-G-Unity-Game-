using UnityEngine;
using TMPro;

public class FloatingUIText : MonoBehaviour
{
    public float lifeTime = 1.2f;       // toplam süre
    public float floatUp = 80f;         // kaç px yukarı çıksın (UI)
    public AnimationCurve ease = AnimationCurve.EaseInOut(0, 0, 1, 1);

    RectTransform rt;
    TextMeshProUGUI tmp;
    Vector2 startPos;
    Color startColor;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        tmp = GetComponent<TextMeshProUGUI>();
        startPos = rt.anchoredPosition;
        startColor = tmp.color;
    }

    public void Play(string text)
    {
        tmp.text = text;
        // başta tam görünür
        var c = tmp.color;
        c.a = 1f;
        tmp.color = c;

        // başlangıç pozisyonunu güncelle
        startPos = rt.anchoredPosition;

        StopAllCoroutines();
        StartCoroutine(Run());
    }

    System.Collections.IEnumerator Run()
    {
        float t = 0f;
        while (t < lifeTime)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / lifeTime);
            float e = ease.Evaluate(p);

            // yukarı kay
            rt.anchoredPosition = startPos + Vector2.up * (floatUp * e);

            // sona doğru fade out
            float alpha = 1f - p;
            var c = startColor;
            c.a = alpha;
            tmp.color = c;

            yield return null;
        }

        Destroy(gameObject);
    }
}
