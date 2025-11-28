using UnityEngine;
using UnityEngine.SceneManagement;

public class BackUIManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 스코어 초기화
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ResetAll();
            }

            // 로비 씬으로 전환
            SceneManager.LoadScene("SLOBBY");
        }
    }

    //public void BackUI()
    //{
    //    // 스코어 초기화
    //    if (UIManager.Instance != null)
    //    {
    //        UIManager.Instance.ResetAll();
    //    }

    //    // 로비 씬으로 전환
    //    SceneManager.LoadScene("SLOBBY");
    //}
}
