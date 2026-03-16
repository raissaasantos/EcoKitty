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
        string url = "URL_DA_API_AQUI";

        WWWForm form = new WWWForm();
        form.AddField("name", PlayerData.playerName);
        form.AddField("score", ScoreManager.Instance.totalGarbage);

        UnityWebRequest request = UnityWebRequest.Post(url, form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score enviado!");
        }
        else
        {
            Debug.Log("Erro: " + request.error);
        }
    }
}