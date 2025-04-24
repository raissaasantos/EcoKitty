using UnityEngine;

public class DogHouseButton : MonoBehaviour
{
    public GameObject shopPanel;

    public void OpenShop()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }
    }

    public void CloseShop()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(false);
        }
    }
}
