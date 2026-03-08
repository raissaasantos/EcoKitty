using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Referência ao painel do menu")]
    public GameObject menuUI; 

    // Método chamado pelo botão de abrir/fechar o menu
    public void ToggleMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf); // Alterna o menu
    }

    // Método chamado pelo botão "Continuar Jogo"
    public void ResumeGame()
    {
        menuUI.SetActive(false); // Fecha o menu
    }

    // Método chamado pelo botão "Reiniciar Jogo"
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual
    }

    // Método chamado pelo botão "Sair"
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TelaInicial"); // 
    }
    // Método chamado pelo botão "Play"
    public void PlayGame()
    {
        SceneManager.LoadScene("Level01"); 
    }
}
