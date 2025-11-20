using UnityEngine;
using UnityEngine.UI;

public class KeyPoint : MonoBehaviour
{
    [SerializeField]
    string keyName;
    [SerializeField]
    KeyManager m_keyManager;
    [SerializeField]
    Text infoText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (keyName)
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
                if (dis <= 120 && dis >= 80)
                {
                    ScoreManager.score += 10;

                    ScoreManager.badPoint++;

                    WhatPoint(ScoreManager.badPoint, "Bad!", collision.gameObject);
                }
                else if (dis < 80 && dis >= 40)
                {
                    ScoreManager.score += 20;

                    ScoreManager.goodPoint++;

                    WhatPoint(ScoreManager.goodPoint, "Good!", collision.gameObject);
                }
                else if (dis < 40)
                {
                    ScoreManager.score += 30;

                    ScoreManager.perfectPoint++;

                    WhatPoint(ScoreManager.perfectPoint, "Perfect!", collision.gameObject);
                }
            }
        }
    }
}
