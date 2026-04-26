using UnityEngine;
using TMPro;

public class GameOverInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI garbageText;
    [SerializeField] private TextMeshProUGUI timeText;

    public void UpdateInfo()
    {
        playerNameText.text = "FUNCIONOU";
        scoreText.text = "FUNCIONOU";
        garbageText.text = "FUNCIONOU";
        timeText.text = "FUNCIONOU";
    }
}