using UnityEngine;
using TMPro;

public class GarbageCounter : MonoBehaviour
{
    public static GarbageCounter Instance;
    public TextMeshProUGUI counterText;
    private int garbageAmount = 0;
    [SerializeField] private string spriteName = "Box";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Define o texto inicial com o sprite
        UpdateCounterText();
    }

    public void AddGarbage()
    {
        garbageAmount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = $"<sprite name=\"{spriteName}\"> {garbageAmount.ToString()}";
    }
}