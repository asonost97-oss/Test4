using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    protected bool m_IsDestroyOnLoad = false;


    protected static T m_Instance;


    public static T Instance // 싱크톤 인스턴스 접근용 프로퍼티
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        Init();
    }

    protected virtual void Init() // 오버로드
    {
        if (m_Instance == null)
        {
            m_Instance = (T)this;

            if (!m_IsDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy() // 삭제 시 실행
    {
        Dispose();
    }

    protected virtual void Dispose() // 삭제 시 추가로 처리해 주어야할 작업을 여기서 처리
    {
        m_Instance = null;
    }
}
