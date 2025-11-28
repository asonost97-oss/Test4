using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWork : MonoBehaviour
{
    public static long autoMoneyIncreaseAmount = 10;

    public static long autoIncreasePrice = 1000;

    void Start()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
