using System.Collections;
//using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    Slider loadingBar;

    [SerializeField]
    float loadingSpeed;

    [SerializeField]
    Text musicNameText;
    
    void Start()
    {
        musicNameText.text = StartManager.musicName;

        LoadingStart("Main");
    }

    public void LoadingStart(string name)
    {
        StartCoroutine(Loading(name));
    }

    IEnumerator Loading(string name)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(name);

        loadingOperation.allowSceneActivation = false; // 로딩이 완료되는대로 씬을 활성화

        while(!loadingOperation.isDone) // 만약 로딩이 완료되지 않았다면
        {
            loadingBar.value += loadingSpeed * Time.deltaTime; // 로딩바 증가

            if(loadingBar.value >= 1f) // 만약 로딩바가 가득 찼다면
            {
                loadingOperation.allowSceneActivation = true; // 씬 활성화 허용
            }

            yield return null; // 1프레임 대기
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
