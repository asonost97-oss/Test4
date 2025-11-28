using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;  // SCORE 텍스트 UI
    [SerializeField] private Slider hpSlider;  // HP 슬라이더 UI

    [SerializeField] private int maxHP = 10;  // 최대 HP

    [SerializeField] private int scoreIncrease = 100;  // 점수 증가량

    bool musicEnd = false;

    private int currentHP;
    private int currentScore = 0;

    // 싱글톤 패턴으로 다른 스크립트에서 접근 가능하게
    public static UIManager Instance { get; private set; }

    public static int FinalScore {  get; private set; }

    // FinalScore 설정 메서드 (외부에서 호출 가능)
    public static void SetFinalScore(int score)
    {
        FinalScore = score;
    }

    public static int PointIncrease
    {
        get
        {
            if (Instance != null)
            {
                return Instance.scoreIncrease;
            }
            return 100;
        }
    }

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SINGAME")
        {
            ResetAll();
        }

        InitializeUI();
    }
        
    void Update()
    {

    }

    // Note가 Remover에 닿았을 때 호출 (HP 감소)
    public void OnNoteMissed()
    {
        if (currentHP > 0)
        {
            currentHP--;
            UpdateHPUI();

            // HP가 0이 되면 게임 오버 처리 (필요시 추가)
            if (currentHP <= 0)
            {
                Debug.Log("게임 오버!");

                FinalScore = currentScore;

                SceneManager.LoadScene("SRESULT");
            }
        }
    }

    // Note를 Tap에서 맞췄을 때 호출 (SCORE 증가)
    public void OnNoteHit()
    {
        currentScore += scoreIncrease;
        UpdateScoreUI();
    }

    // HP UI 업데이트
    private void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.value = (float)currentHP / maxHP;
        }
    }

    // SCORE UI 업데이트
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        FinalScore = 0;
        UpdateScoreUI();
    }

    // 현재 HP 반환
    public int GetCurrentHP()
    {
        return currentHP;
    }

    // 현재 SCORE 반환
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ResetHP()
    {
        currentHP = maxHP;
        UpdateHPUI();
        Debug.Log("HP 초기화 완료");
    }

    public void ResetAll()
    {
        ResetScore();
        ResetHP();
    }

    private void InitializeUI()
    {
        // UI 업데이트
        UpdateHPUI();
        UpdateScoreUI();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"씬 로드됨: {scene.name}");

        // SINGAME 씬으로 들어올 때 게임 상태 초기화
        if (scene.name == "SINGAME")
        {
            Debug.Log("SINGAME 씬 진입 - 게임 상태 초기화");
            ResetAll();
            InitializeUI();
        }
    }

    void OnDestroy()
    {
        // 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

