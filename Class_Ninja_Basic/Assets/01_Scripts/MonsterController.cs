using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed = 5f;

    public int damage = 1;

    public int maxHp = 3;

    public int currentHp;

    bool isDead = false;

    public int scorePoint = 100;

    public float scaleAmount = 0.05f;

    //Scoremanager scoremanager;

    Transform target;

    Vector3 vt;

    SpriteRenderer sr;

    Rigidbody2D rb;

    void Start()
    {
        // 현재 스케일 값을 저장
        vt = transform.localScale;

        currentHp = maxHp;

        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");


        // 플레이어 찾기
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player 오브젝트를 찾을 수 없습니다.");
        }

        //scoreManager = FindObjectOfType<ScoreManager>();
        //if(scoreManager == null)
        //{
        //    Debug.LogWarning("ScoreManager 오브젝트를 찾을 수 없습니다.");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // 시간에 따라 0~1 사이를 반복 하 값 (Pingpong)
        float scaleProgress = Mathf.PingPong(Time.time * speed, 1f);

        //범위
        float scaleChange = (scaleProgress * 2 - 1) * scaleAmount;

        // 새로운 스케일 값 계산
        Vector3 newScale = vt * (1 + scaleChange);

        transform.localScale = newScale;

        
    }

    private void FixedUpdate()
    {
        if(isDead || target == null)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (direction.x > 0)
        {
            sr.flipX = false; // 오른쪽 이동시 스프라이트 기본 방향
        }
        else
        {
            sr.flipX = true; // 왼쪽 이동시 스프라이트 플립
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>(); // 플레이어 스크립트 가져오기

            if (player != null)
            {
                player.TakeDamage(damage);
            }

            gameObject.SetActive(false); // 몬스터 비활성화
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHp -= damage;

        Debug.Log(gameObject.name + " 이(가)" + damage + "데미지를 입었습니다.");

        if (currentHp <= 0)
        {
            Die();
        }
        else
        {
                       // 효과음도 추가 가능
            //Debug.Log(gameObject.name + "의 남은 체력: " + currentHp);

            StartCoroutine(HitEffect());
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " 이(가) 사망했습니다.");

        // 점수 추가
        //if(scoreManager != null)
        //{
        //    scoreManager.AddScore(scorePoint);
        //}
        // 사망 효과음 추가 가능

        gameObject.SetActive(false); // 몬스터 비활성화
    }

    IEnumerator HitEffect()
    {
        sr.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        sr.color = Color.white;
    }
}


