using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIManager : MonoBehaviour
{
    public static APIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SendScore()
    {
        StartCoroutine(PostScore());
    }

    IEnumerator PostScore()
    {
        string url = "http://13.218.217.109:8891/v1/api/ecoKitty/";

        WWWForm form = new WWWForm();
        form.AddField("name", PlayerData.playerName);
        form.AddField("score", ScoreManager.Instance.totalScore);

        UnityWebRequest request = UnityWebRequest.Post(url, form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score enviado com sucesso!");
        }
        else
        {
            Debug.LogError("Erro ao enviar score: " + request.error);
        }
    }
}