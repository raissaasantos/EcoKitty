using TMPro;
using UnityEngine;

public class NameInputUI : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SaveName()
    {
        PlayerData.SaveName(inputField.text);
    }
}