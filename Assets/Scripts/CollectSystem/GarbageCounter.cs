using UnityEngine;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.UIElements;

public class GarbageCounter : MonoBehaviour
{
    public static GarbageCounter Instance;

    public TextMeshProUGUI counterText;
    [SerializeField] private GameObject nextLevelScreen;

    private int collectedGarbageCount = 0;
    private int totalGarbageInScene;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalGarbageInScene = GameObject.FindGameObjectsWithTag("Garbage").Length;
        collectedGarbageCount = 0;

        UpdateCounterText();
    }

    public void AddGarbage()
    {
        collectedGarbageCount++;

        UpdateCounterText();

        if (collectedGarbageCount >= totalGarbageInScene)
        {
            GameManager.Instance.PauseTimer();

            nextLevelScreen.SetActive(true);
        }
    }

    private void UpdateCounterText()
    {
        counterText.text = $"<sprite name=\"Box\"> {collectedGarbageCount}";
    }

    public int GetCollectedGarbage()
    {
        return collectedGarbageCount;
    }
}



/*using UnityEngine;
using TMPro;

public class GarbageCounter : MonoBehaviour
{
    public static GarbageCounter Instance;
    public TextMeshProUGUI counterText;
    private int collectedGarbageCount = 0;
    [SerializeField] private string spriteName = "Box";
    private int totalGarbageInScene;
    [SerializeField] private GameObject nextLevelScreen; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }

       
        //UpdateCounterText();
    }

    void Start()
    {
        totalGarbageInScene = GameObject.FindGameObjectsWithTag("Garbage").Length;
        collectedGarbageCount = 0;
        UpdateCounterText();

        Debug.Log("Total de lixos na cena: " + totalGarbageInScene);
    }

    public void AddGarbage()
    {
        collectedGarbageCount++;
        UpdateCounterText();

        if (collectedGarbageCount >= totalGarbageInScene)
        {
            Debug.Log("Todos os lixos coletados! Nível Completo!");
            ShowNextLevelScreen();
        }
    }

    private void UpdateCounterText()
    {
       counterText.text = $"<sprite name=\"{spriteName}\"> {collectedGarbageCount.ToString()}";
    }

    
    private void ShowNextLevelScreen()
    {
        if (nextLevelScreen != null)
        {
            nextLevelScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("GarbageCounter: 'Next Level Screen' não foi atribuída no Inspector!");
        }
    }
}*/