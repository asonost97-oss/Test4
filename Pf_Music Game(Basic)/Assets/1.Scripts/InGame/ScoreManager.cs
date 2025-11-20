using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int missPoint;
    public static int badPoint;
    public static int goodPoint;
    public static int perfectPoint;

    public static int score = 0;

    [SerializeField]
    Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
