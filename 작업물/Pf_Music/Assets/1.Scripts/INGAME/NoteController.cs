using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    float minSpeed = 50f;
    [SerializeField]
    float maxSpeed = 100f;

    [SerializeField]
    GameObject pointTxtPrefab;

    private bool isCollidingWithTap = false;
    private GameObject tapObject;

    public float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        tapObject = GameObject.Find("Tap");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (isCollidingWithTap && Input.GetKeyDown(KeyCode.Space))
        {
            // Note를 맞췄을 때 SCORE 증가
            if (UIManager.Instance != null)
            {
                UIManager.Instance.OnNoteHit();
            }

            ShowPointTxt();

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == tapObject || other.CompareTag("Tap")) ;
        {
            isCollidingWithTap = true;
        }

        if (other.CompareTag("Remover"))
        {
            RemoverNote();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == tapObject || other.CompareTag("Tap")) ;
        {
            isCollidingWithTap = false;
        }
    }

    public void RemoverNote()
    {
        // Note를 놓쳤을 때 HP 감소
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnNoteMissed();
        }
        Destroy(gameObject);
    }

    void ShowPointTxt()
    {
        if (pointTxtPrefab != null && tapObject != null)
        {
            // Tap 위치에 PointTxt 생성
            GameObject pointTxt = Instantiate(pointTxtPrefab, tapObject.transform.position, Quaternion.identity);

            // Canvas의 자식으로 설정 (UI 요소인 경우)
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                pointTxt.transform.SetParent(canvas.transform, false);
                // Tap의 위치를 UI 좌표로 변환
                RectTransform tapRect = tapObject.GetComponent<RectTransform>();
                RectTransform pointRect = pointTxt.GetComponent<RectTransform>();
                if (tapRect != null && pointRect != null)
                {
                    pointRect.anchoredPosition = tapRect.anchoredPosition;
                }
            }
        }
    }
}
