using UnityEngine;
using System.Collections.Generic;

public class CoolTime
{
    public float coolTime;

    float coolCnt = 0f;

    void Start()
    {
        coolCnt = Time.time;
    }

    public float Timer(float t)
    {
        coolTime += Time.deltaTime;

        if(coolCnt + t <= Time.time)
        {
            coolCnt = Time.time;
            
            coolTime = 0f;
        }

        return coolTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
