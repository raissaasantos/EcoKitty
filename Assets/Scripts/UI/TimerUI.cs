using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        float time = GameManager.Instance.currentTime;

        int seconds = Mathf.CeilToInt(time);

        //timerText.text = "Tempo: " + seconds.ToString();
        timerText.text = seconds.ToString();
    }
}