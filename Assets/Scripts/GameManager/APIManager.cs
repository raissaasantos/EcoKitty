using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

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
        string url =
            "http://54.160.243.136:8891/v1/api/ecoKitty/";

        ScoreData data = new ScoreData();

        data.id = 0;

        data.name = PlayerData.playerName;

        data.score = ScoreManager.Instance.totalScore;

        string json =
            JsonUtility.ToJson(data);

        Debug.Log(json);

        byte[] bodyRaw =
            Encoding.UTF8.GetBytes(json);

        UnityWebRequest request =
            new UnityWebRequest(url, "POST");

        request.uploadHandler =
            new UploadHandlerRaw(bodyRaw);

        request.downloadHandler =
            new DownloadHandlerBuffer();

        request.SetRequestHeader(
            "Accept",
            "application/json"
        );

        request.SetRequestHeader(
            "Content-Type",
            "application/json"
        );

        yield return request.SendWebRequest();

        Debug.Log(
            "CODE: " + request.responseCode
        );

        Debug.Log(
            "BODY: " + request.downloadHandler.text
        );

        if (request.result ==
            UnityWebRequest.Result.Success)
        {
            Debug.Log(
                "Score enviado com sucesso!"
            );
        }
        else
        {
            Debug.LogError(
                "Erro: " + request.error
            );
        }
    }
}

[System.Serializable]
public class ScoreData
{
    public int id;

    public string name;

    public int score;
}




/*using UnityEngine;
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
        string url = "http://54.160.243.136:8891/v1/api/ecoKitty/";

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
}*/