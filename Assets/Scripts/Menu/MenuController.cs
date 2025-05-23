using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Refer�ncia ao painel do menu")]
    public GameObject menuUI; // Arraste aqui o painel com os bot�es do menu

    // M�todo chamado pelo bot�o de abrir/fechar o menu
    public void ToggleMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf); // Alterna o menu
    }

    // M�todo chamado pelo bot�o "Continuar Jogo"
    public void ResumeGame()
    {
        menuUI.SetActive(false); // Fecha o menu
    }

    // M�todo chamado pelo bot�o "Reiniciar Jogo"
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual
    }

    // M�todo chamado pelo bot�o "Sair"
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TelaInicial"); // Troque "MainMenu" pelo nome exato da sua cena inicial
    }
    // M�todo chamado pelo bot�o "Play"
    public void PlayGame()
    {
        SceneManager.LoadScene("Level01"); // Substitua pelo nome exato da sua cena de jogo
    }
}
