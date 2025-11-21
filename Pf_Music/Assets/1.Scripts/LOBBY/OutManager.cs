using UnityEngine;

public class OutManager : MonoBehaviour
{
    public void ExitGame()
    {

#if UNITY_EDITOR
        // 에디터에서는 플레이 모드 종료
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
        // 모바일에서는 애플리케이션 종료
        Application.Quit();
#else
        // PC 빌드에서는 애플리케이션 종료
        Application.Quit();
#endif
    }
}
