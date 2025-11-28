using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Animation logoAnim;
    public TextMeshProUGUI logoTxt;

    public GameObject title;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingProgressTxt;

    AsyncOperation m_AsyncOperation;

    private void Awake()
    {
        logoAnim.gameObject.SetActive(true);
        title.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(LoadGameCo());
    }

    IEnumerator LoadGameCo()
    {
        Logger.Log($"{GetType()}::LoadGameCo");

        logoAnim.Play(); // 로고 애니메이션 재생

        yield return new WaitForSeconds(logoAnim.clip.length); // 애니메이션 길이만큼 대기

        logoAnim.gameObject.SetActive(false);
        title.SetActive(true);

        m_AsyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);

        if (m_AsyncOperation == null)
        {
            Logger.Log("Lobby async loading error.");

            yield break;
        }

        m_AsyncOperation.allowSceneActivation = false;

        loadingSlider.value = 0.5f;
        loadingProgressTxt.text = $"{(int)(loadingSlider.value * 100)}%";
        yield return new WaitForSeconds(0.5f);

        while (!m_AsyncOperation.isDone) // 로딩이 진행중일떄
        {
            loadingSlider.value = m_AsyncOperation.progress < 0.5 ? 0.5f : m_AsyncOperation.progress;
            loadingProgressTxt.text = $"{(int)(loadingSlider.value * 100)}%";

            if (m_AsyncOperation.progress >= 0.9f)
            {
                m_AsyncOperation.allowSceneActivation = true;
                yield break;
            }

            yield return null;
        }
    }
}
