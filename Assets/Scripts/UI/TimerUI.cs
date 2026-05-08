using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        timerText.text = Mathf.CeilToInt(GameManager.Instance.currentTime).ToString();
    }
}