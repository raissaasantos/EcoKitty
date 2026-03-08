using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private AudioSource audioSource;

    [Header("Fade")]
    public float fadeDuration = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Evita duplicata
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TelaInicial")
            StartCoroutine(SwitchMusic(menuMusic));
        else if (scene.name == "Level01")
            StartCoroutine(SwitchMusic(gameMusic));
    }

    private IEnumerator SwitchMusic(AudioClip newClip)
    {
        if (audioSource.isPlaying)
            yield return StartCoroutine(FadeOut());

        audioSource.clip = newClip;
        audioSource.Play();
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float startVol = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVol, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 0;
    }

    private IEnumerator FadeIn()
    {
        float targetVol = 1f;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, targetVol, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVol;
    }
}

