using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private bool scoreSent = false;

    public void GameOver()
    {

        if (gameOverScreen.activeSelf) return;

        gameOverScreen.SetActive(true);

        gameOverScreen.GetComponent<GameOverInfoUI>().UpdateInfo();

        SoundManager.instance.PlaySound(gameOverSound);

        GameManager.Instance.PauseTimer();

        /*if (gameOverScreen.activeSelf) return; //so it doesnt open lots of times

        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);

        GameManager.Instance.PauseTimer();*/
    }

    public void LoadLevel2()
    {
        GameManager.Instance.ResumeTimer();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level02");
    }

    public void LoadLevel3()
    {
        GameManager.Instance.ResumeTimer();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level03");
    }

    public void FinishGame()
    {
        if (scoreSent) return;

        scoreSent = true;

        GameManager.Instance.PauseTimer();

        APIManager.Instance.SendScore();

        Time.timeScale = 1f;

        SceneManager.LoadScene("TelaInicial");
    }
}