//using UnityEngine;
//using System.Collections;

//public class NoteSpawnManager : MonoBehaviour
//{
//    [SerializeField]
//    GameObject notePrefab;

//    [SerializeField]
//    RectTransform spawnPoint;

//    [SerializeField]
//    float spawnInterval = 3f; // 생성 간격 (초) - Inspector에서 조정 가능

//    Coroutine spawnCoroutine;

//    void Start()
//    {
//        // null 체크 후에만 코루틴 시작
//        if (notePrefab != null && spawnPoint != null)
//        {
//            // 코루틴 시작
//            spawnCoroutine = StartCoroutine(SpawnNoteCoroutine());
//        }
//    }

//    void Update()
//    {

//    }

//    // 코루틴: 3초마다 노트 생성
//    IEnumerator SpawnNoteCoroutine()
//    {
//        while (true)
//        {
//            SpawnNote();
//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }

//    public void SpawnNote()
//    {

//            GameObject newNote = Instantiate(notePrefab, spawnPoint);

//            // 생성된 노트의 위치를 spawnPoint 기준으로 설정
//            RectTransform noteRect = newNote.GetComponent<RectTransform>();
//            if (noteRect != null)
//            {
//                noteRect.anchoredPosition = Vector2.zero;
//            }
//    }
//}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NoteSpawnManager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;  // 재생할 음악 파일
    [SerializeField] private AudioSource audioSource;  // AudioSource 컴포넌트
    [SerializeField] private float originalBPM = 120f;  // 원래 음악의 BPM

    [SerializeField] private GameObject notePrefab;  // 스폰할 Note 프리팹
    [SerializeField] private Transform spawnPoint;  // Note 스폰 위치
    [SerializeField] private bool playOnStart = true;  // 시작 시 자동 재생

    [SerializeField] private float tempoMultiplier = 0.5f;  // 템포 배율 (0.5 = 2배 느리게)

    [SerializeField] private float gameDuration = 60f;  // 게임 지속 시간 (초) - 1분

    private float currentBPM;  // 현재 BPM (템포 조정 후)
    private float beatInterval;  // 비트 간격 (초)
    private float nextSpawnTime;  // 다음 스폰 시간
    private bool isPlaying = false;

    private float gameStartTime;  // 게임 시작 시간
    private bool gameEnded = false;  // 게임 종료 여부

    void Start()
    {
        // AudioSource 설정
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // 음악 클립 설정
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
        }

        // 템포를 2배 낮춤 (BPM을 절반으로)
        currentBPM = originalBPM * tempoMultiplier;
        beatInterval = 60f / currentBPM;  // 비트 간격 계산 (초 단위)

        // 템포에 맞춰 음악 재생 속도 조정
        audioSource.pitch = tempoMultiplier;
        audioSource.loop = false;

        // SpawnPoint 자동 찾기
        if (spawnPoint == null)
        {
            GameObject spawnObj = GameObject.Find("SpawnPoint");
            if (spawnObj != null)
            {
                spawnPoint = spawnObj.transform;
            }
            else
            {
                spawnPoint = transform;  // 없으면 자기 자신의 위치 사용
            }
        }

        Debug.Log($"음악 BPM 설정: 원래 {originalBPM} BPM -> {currentBPM} BPM (템포: {tempoMultiplier}x)");
        Debug.Log($"비트 간격: {beatInterval}초");

        // 시작 시 자동 재생
        if (playOnStart && musicClip != null)
        {
            StartMusic();
        }
    }

    void Update()
    {
        // 게임 종료 체크 (1분 경과)
        if (!gameEnded && Time.time - gameStartTime >= gameDuration)
        {
            EndGame();
            return;
        }

        if (isPlaying && audioSource.isPlaying)
        {
            // 음악 재생 시간에 맞춰 Note 스폰
            if (Time.time >= nextSpawnTime)
            {
                SpawnNote();
                nextSpawnTime = Time.time + beatInterval;
            }
        }
    }

    // 게임 종료 처리
    private void EndGame()
    {
        if (gameEnded) return;  // 이미 종료 처리했으면 중복 실행 방지

        gameEnded = true;
        Debug.Log("1분 경과! 게임 종료");

        // 음악 정지
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // 최종 스코어 저장 및 씬 전환
        if (UIManager.Instance != null)
        {
            int finalScore = UIManager.Instance.GetCurrentScore();
            UIManager.SetFinalScore(finalScore);
            Debug.Log($"최종 스코어 저장: {finalScore}");
        }

        // SRESULT 씬으로 전환
        SceneManager.LoadScene("SRESULT");
    }


    // 음악 재생 시작
    public void StartMusic()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            isPlaying = true;
            nextSpawnTime = Time.time + beatInterval;  // 첫 번째 Note 스폰 시간 설정

            Debug.Log($"음악 재생 시작: {audioSource.clip.name}");
            Debug.Log($"첫 번째 Note는 {beatInterval}초 후에 스폰됩니다.");
        }
        else
        {
            Debug.LogWarning("AudioSource 또는 음악 클립이 설정되지 않았습니다!");
        }
    }

    public void SpawnNote()
    {

        GameObject newNote = Instantiate(notePrefab, spawnPoint);

        // 생성된 노트의 위치를 spawnPoint 기준으로 설정
        RectTransform noteRect = newNote.GetComponent<RectTransform>();
        if (noteRect != null)
        {
            noteRect.anchoredPosition = Vector2.zero;
        }
    }

    // 음악 정지
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            isPlaying = false;
            Debug.Log("음악 정지");
        }
    }

    // 템포 변경 (런타임에서 조정 가능)
    public void SetTempo(float multiplier)
    {
        tempoMultiplier = multiplier;
        currentBPM = originalBPM * tempoMultiplier;
        beatInterval = 60f / currentBPM;

        if (audioSource != null)
        {
            audioSource.pitch = tempoMultiplier;
        }

        Debug.Log($"템포 변경: {currentBPM} BPM (템포: {tempoMultiplier}x, 비트 간격: {beatInterval}초)");
    }

    // BPM 변경
    public void SetBPM(float bpm)
    {
        originalBPM = bpm;
        currentBPM = originalBPM * tempoMultiplier;
        beatInterval = 60f / currentBPM;

        Debug.Log($"BPM 변경: 원래 {originalBPM} BPM -> {currentBPM} BPM (템포: {tempoMultiplier}x)");
    }

    // 현재 재생 중인지 확인
    public bool IsPlaying()
    {
        return isPlaying && audioSource != null && audioSource.isPlaying;
    }
}




