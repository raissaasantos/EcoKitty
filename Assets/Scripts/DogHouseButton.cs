using UnityEngine;

public class DogHouseButton : MonoBehaviour
{
    public GameObject shopPanel; // arraste o painel da loja aqui pelo Inspector

    // Este método será chamado quando clicar no botão
    public void OpenShop()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }
    }
}
