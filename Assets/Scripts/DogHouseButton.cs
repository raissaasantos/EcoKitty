using UnityEngine;

public class DogHouseButton : MonoBehaviour
{
    public GameObject shopPanel; // arraste o painel da loja aqui pelo Inspector

    // Este m�todo ser� chamado quando clicar no bot�o
    public void OpenShop()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }
    }
}
