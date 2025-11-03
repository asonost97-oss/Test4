using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPointTr;

    [SerializeField]
    GameObject[] spawnPoints;

    [SerializeField]
    GameObject gameUI;

    public int spawnCount = 0;
    
    void Start()
    {
        InvokeRepeating("CreatePoint", 2f, Random.Range(1, 6));

        
    }

    void CreatePoint()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject m_SpawnPoints = Instantiate(spawnPoints[i]);

            m_SpawnPoints.transform.SetParent(gameUI.transform);
            m_SpawnPoints.transform.localPosition = spawnPointTr[i].localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
