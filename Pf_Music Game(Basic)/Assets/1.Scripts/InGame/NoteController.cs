using UnityEngine;

public class NoteController : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float minSpeed = 200f;  // 최소 속도
    [SerializeField] private float maxSpeed = 400f;  // 최대 속도

    private float moveSpeed;  // 실제 이동 속도
    //private float targetX = -15f;  // 노트가 사라질 X 좌표 (화면 왼쪽 밖)
    private RectTransform rectTransform;  // UI 요소인 경우
    private bool isUIElement;  // UI 요소인지 여부

    void Start()
    {
        // 랜덤한 속도 설정
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // UI 요소인지 확인
        rectTransform = GetComponent<RectTransform>();
        isUIElement = rectTransform != null;
    }

    void Update()
    {
        if (isUIElement && rectTransform != null)
        {
            // UI 요소인 경우 RectTransform의 anchoredPosition 사용
            Vector2 currentPos = rectTransform.anchoredPosition;
            rectTransform.anchoredPosition = new Vector2(
                currentPos.x - moveSpeed * Time.deltaTime,  // UI는 픽셀 단위이므로 스케일 조정
                currentPos.y
            );
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        }
    }

    // 외부에서 속도를 설정할 수 있는 메서드
    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    // 외부에서 랜덤 속도를 다시 설정할 수 있는 메서드
    public void SetRandomSpeed(float min, float max)
    {
        moveSpeed = Random.Range(min, max);
    }

    // RemoveNote와 충돌 시 제거
    void OnTriggerEnter2D(Collider2D other)
    {
        // RemoveNote GameObject와 충돌했는지 확인
        if (other.CompareTag("RemoveNote"))
        {
            Destroy(gameObject);
        }
    }
}

