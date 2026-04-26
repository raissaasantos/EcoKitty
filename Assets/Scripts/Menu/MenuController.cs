using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Referência ao painel do menu")]
    public GameObject menuUI;

    [Header("Painel para digitar nome")]
    public GameObject namePanel;

    /*public void ToggleMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
    }*/

    public void ToggleMenu()
    {
        bool isOpen = !menuUI.activeSelf;

        menuUI.SetActive(isOpen);

        if (isOpen)
            GameManager.Instance.PauseTimer();
        else
            GameManager.Instance.ResumeTimer();
    }

    /*public void ResumeGame()
    {
        menuUI.SetActive(false);
    }*/

    public void ResumeGame()
    {
        menuUI.SetActive(false);
        GameManager.Instance.ResumeTimer();
    }

    public void RestartGame()
    {
        GameManager.Instance.ResetTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void PlayGame()
    {   
        //Always ask player's name
        namePanel.SetActive(true);

        /*
         * Ask player's name once
        PlayerData.LoadName();

        if (PlayerData.playerName == "")
        {
            namePanel.SetActive(true); // mostra tela de digitar nome
        }
        else
        {
            SceneManager.LoadScene("Level01");
        }
        */
    }

    public void ConfirmName()
    {
        GameManager.Instance.ResetTimer();
        SceneManager.LoadScene("Level01");
    }
}
