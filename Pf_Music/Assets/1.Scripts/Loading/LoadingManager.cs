using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadindManager : MonoBehaviour
{
    [SerializeField]
    Slider loadingBar;

    [SerializeField]
    float loadingSpeed;

    [SerializeField]
    Text musicNameText;


    private void Start()
    {
        musicNameText.text = SelectManager.musicName;

        LoadingStart("SINGAME");
    }

    public void LoadingStart(string name)
    {
        StartCoroutine(Loading(name));
    }

    IEnumerator Loading(string name)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(name);

        loadingOperation.allowSceneActivation = false; // 로딩 완료시 씬 활성화

        while (!loadingOperation.isDone)
        {
            loadingBar.value += loadingSpeed * Time.deltaTime;

            if (loadingBar.value >= 1f)
            {
                loadingOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
