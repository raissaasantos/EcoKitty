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



/*using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        if(GameManager.Instance == null) return;

        float time = GameManager.Instance.currentTime;

        int seconds = Mathf.CeilToInt(time);

        //timerText.text = "Tempo: " + seconds.ToString();
        timerText.text = seconds.ToString();
    }
}*/