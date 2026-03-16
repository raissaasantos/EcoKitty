using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float totalTime = 60f;
    public float currentTime;

    public bool timerRunning = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentTime = totalTime;

            // Carrega o nome salvo
            PlayerData.LoadName();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerRunning = false;

                Debug.Log("Tempo acabou!");

                // Aqui você pode chamar Game Over futuramente
            }
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
}