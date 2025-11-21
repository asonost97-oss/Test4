using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour
{
    [Header("노트 생성 설정")]
    [SerializeField] private GameObject notePrefab;  // 노트 프리팹
    [SerializeField] private Transform spawnPoint;  // 노트 생성 위치 (Note GameObject의 Transform)
    [SerializeField] private Transform parentCanvas;  // 부모 Canvas (UI 요소인 경우)
    [SerializeField] private float spawnInterval = 1f;  // 생성 간격 (초)

    [Header("속도 범위")]
    [SerializeField] private float minSpeed = 200f;  // 최소 속도
    [SerializeField] private float maxSpeed = 400f;  // 최대 속도

    private Coroutine spawnCoroutine;

    void Start()
    {
        // 자동으로 노트 생성 시작
        StartSpawning();
    }

    // 노트 생성 시작
    public void StartSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine(SpawnNotes());
    }

    // 노트 생성 중지
    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    // 노트 생성 코루틴
    private IEnumerator SpawnNotes()
    {
        while (true)
        {
            SpawnNote();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // 노트 하나 생성
    public void SpawnNote()
    {
        // Note GameObject의 transform 위치에서 생성
        Vector3 spawnPosition = spawnPoint.position;

        // Instantiate로 노트 생성 (부모 지정)
        GameObject newNote;
        if (parentCanvas != null)
        {
            // UI 요소인 경우 부모 Canvas 지정
            newNote = Instantiate(notePrefab, spawnPosition, Quaternion.identity, parentCanvas);
        }
        else
        {
            // 일반 GameObject인 경우
            newNote = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
        }

        // UI 요소인 경우 RectTransform 설정
        RectTransform rectTransform = newNote.GetComponent<RectTransform>();
        if (rectTransform != null && spawnPoint is RectTransform)
        {
            RectTransform spawnRect = spawnPoint as RectTransform;
            rectTransform.anchoredPosition = spawnRect.anchoredPosition;
            rectTransform.localScale = Vector3.one;
        }

        // 노트에 랜덤 속도 설정
        NoteController noteController = newNote.GetComponent<NoteController>();
        if (noteController != null)
        {
            noteController.SetRandomSpeed(minSpeed, maxSpeed);
        }
    }
}

