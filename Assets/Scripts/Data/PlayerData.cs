using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string playerName;

    public static void SaveName(string name)
    {
        playerName = name;
    }
}



/*
 * Saves the name just once
 * using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string playerName;

    void Awake()
    {
        LoadName();
    }

    public static void SaveName(string name)
    {
        playerName = name;
        PlayerPrefs.SetString("PLAYER_NAME", name);
        PlayerPrefs.Save();
    }

    public static void LoadName()
    {
        playerName = PlayerPrefs.GetString("PLAYER_NAME", "");
    }
}*/