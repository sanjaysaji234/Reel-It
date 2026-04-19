using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;

    [Header("Settings")]
    [SerializeField] private float minLoadTime = 2f; // Minimum time screen stays visible

    public void LoadGameScene(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        loadingScreen.SetActive(true);
        loadingBar.value = 0;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        float timer = 0;

        while (timer < minLoadTime || operation.progress < 0.9f)
        {
            timer += Time.unscaledDeltaTime;

            float progress = Mathf.Min(timer / minLoadTime, operation.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }

        loadingBar.value = 1f;
        Time.timeScale = 1f;
        operation.allowSceneActivation = true;
    }
}