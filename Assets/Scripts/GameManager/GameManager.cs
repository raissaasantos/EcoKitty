using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float currentTime = 60f;
    private bool timerRunning = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerRunning = false;

            FindFirstObjectByType<UIManager>()?.GameOver();
        }
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }

    public void ResumeTimer()
    {
        timerRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = 60f;
        timerRunning = true;
    }
}

/*using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float currentTime = 60f;
    private bool timerRunning = true;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerRunning = false;

            FindFirstObjectByType<UIManager>().GameOver();
        }
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }

    public void ResumeTimer()
    {
        timerRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = 60f;
        timerRunning = true;
    }
}*/