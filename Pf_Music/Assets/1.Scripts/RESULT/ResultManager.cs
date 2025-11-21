using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text totalScoreText;  // TotalScore 텍스트 UI

    void Start()
    {
        // UIManager에서 최종 스코어 가져와서 표시
        UpdateTotalScore();
    }

    // TotalScore 텍스트 업데이트
    private void UpdateTotalScore()
    {
        if (totalScoreText != null)
        {
            // UIManager의 FinalScore 가져오기
            int finalScore = UIManager.FinalScore;
            totalScoreText.text = "BEST SCORE: " +finalScore.ToString("###,###");
            Debug.Log($"결과 화면 스코어 표시: {finalScore}");
        }
    }
}
