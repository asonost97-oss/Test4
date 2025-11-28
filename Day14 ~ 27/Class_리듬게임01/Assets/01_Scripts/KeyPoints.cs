using UnityEngine;
using UnityEngine.UI;

public class KeyPoints : MonoBehaviour
{
    [SerializeField]
    string keyName;
    [SerializeField]
    KeyManager m_keyManager;
    [SerializeField]
    Text infoText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch(keyName)
        {
            case "Key_1":
                PointCheck(0, collision);
                break;
            case "Key_2":
                PointCheck(1, collision);
                break;
            case "Key_3":
                PointCheck(2, collision);
                break;
            case "Key_4":
                PointCheck(3, collision);
                break;
            case "Key_5":
                PointCheck(4, collision);
                break;
        }
    }

    void WhatPoint(int scorePoint, string infoTxt, GameObject obj)
    {
        scorePoint++;

        infoText.text = infoTxt;

        Destroy(obj);
    }

    void PointCheck(int i, Collider2D collision)
    {
        if (m_keyManager != null)
        {
            float dis = Vector2.Distance(transform.position, collision.transform.position);

            if (m_keyManager.isKeyPut[i])
            {
                if(dis <= 120 && dis >= 80)
                {
                    ScorePoint.score += 10;

                    ScorePoint.badPoint++;

                    WhatPoint(ScorePoint.badPoint, "Bad!", collision.gameObject);
                }
                else if(dis < 80 && dis >= 40)
                {
                    ScorePoint.score += 20;

                    ScorePoint.goodPoint++;

                    WhatPoint(ScorePoint.goodPoint, "Good!", collision.gameObject);
                }
                else if(dis < 40)
                {
                    ScorePoint.score += 30;
                    
                    ScorePoint.perfectPoint++;

                    WhatPoint(ScorePoint.perfectPoint, "Perfect!", collision.gameObject);
                }
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
