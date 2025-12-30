using UnityEngine;
using TMPro;

public class PlaneTriggerText : MonoBehaviour
{
    public GameObject textUI; // Text objesi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(false);
        }
    }
}