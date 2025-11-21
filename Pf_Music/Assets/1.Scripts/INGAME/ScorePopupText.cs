using UnityEngine;
using UnityEngine.UI;

public class ScorePopupText : MonoBehaviour
{
    private Text txt;
    [SerializeField] private float destroyTime = 0.2f;  // 사라질 시간

    void Start()
    {
        txt = transform.GetComponentInChildren<Text>();

        if (txt != null)
        {
            // UIManager에서 점수 증가량 가져오기
            txt.text = "+" + UIManager.PointIncrease.ToString("###,###");
        }

        // 0.5초 후 자동으로 사라지기
        Destroy(gameObject, destroyTime);
    }
}