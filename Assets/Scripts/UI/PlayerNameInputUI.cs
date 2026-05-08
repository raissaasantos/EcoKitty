using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInputUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public void SaveName()
    {
        if (inputField.text.Trim() == "") return;

        PlayerData.SaveName(inputField.text);

        GameManager.Instance.ResetTimer();

        SceneManager.LoadScene("Level01");
    }
}

