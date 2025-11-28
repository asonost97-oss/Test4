using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public static class Logger
{
    [Conditional("DEV_VER")]

    public static void Log(string message) //워밍 로그 흰색
    {
        UnityEngine.Debug.LogFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss.fff"), message);
    }

    [Conditional("DEV_VER")]
    public static void LogWarning(string message) //경고 로그 노란색
    {
        UnityEngine.Debug.LogWarningFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss.fff"), message);
    }

    public static void LogError(string message) //에러 로그 빨간색
    {
        UnityEngine.Debug.LogErrorFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss.fff"), message);
    }
}
