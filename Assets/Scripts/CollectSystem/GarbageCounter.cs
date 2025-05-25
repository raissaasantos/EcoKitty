using UnityEngine;
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
            Debug.Log("Todos os lixos coletados! N�vel Completo!");
            ShowNextLevelScreen();
        }
    }

    private void UpdateCounterText()
    {
       counterText.text = $"<sprite name=\"{spriteName}\"> {collectedGarbageCount.ToString()}";
    }

    // NOVO M�TODO: Ativa a tela de "pr�ximo n�vel"
    private void ShowNextLevelScreen()
    {
        if (nextLevelScreen != null)
        {
            nextLevelScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("GarbageCounter: 'Next Level Screen' n�o foi atribu�da no Inspector!");
        }
    }
}