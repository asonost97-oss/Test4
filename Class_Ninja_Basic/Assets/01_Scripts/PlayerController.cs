using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public int damage = 1;

    public int maxHp = 5;

    public int currentHp;

    Rigidbody2D rb;  // 물리 처리
    Vector2 moveDir; // 이동 방향
    SpriteRenderer sr;   // 플립용
    Animator anim; // 애니메이터
    bool isDead = false; // 죽음 상태

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        currentHp = maxHp; // 게임 시작시 최대 체력으로 설정
    }

    // Update is called once per frame
    void Update()
    {
        // 사망 상태면 이동 불가
        if (isDead)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");  // x

        float v = Input.GetAxisRaw("Vertical");  // y

        moveDir = new Vector2(h, v);



        if (moveDir.magnitude > 0)
        {
            moveDir = moveDir.normalized;

            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (h != 0)
        {
            sr.flipX = h < 0; // 왼쪽 이동시 스프라이트 플립
        }
        else
        {
            sr.flipX = sr.flipX; // 가만히 있을땐 현재 플립 상태 유지
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();  //// 테스트용 사망 애니메이션 재생
        }
    }

    private void FixedUpdate()
    {
        if(isDead)
        {
            return;
        }

        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);       

    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
        else
        {
            // 효과음도 추가 가능
            Debug.Log("플레이어가 데미지를 입었습니다. 남은 체력: " + currentHp);
        }
    }

    void Die()
    {
        isDead = true;

        anim.SetTrigger("Death");

        GetComponent<Collider2D>().enabled = false; // 충돌 비활성화

        rb.linearVelocity = Vector2.zero; // 사망시 속도 0으로

        Debug.Log("플레이어가 사망했습니다.");

        // 추가적인 사망 처리 로직 (게임 오버 화면 등) 여기에 작성

        //GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        //if (gameOverManager != null)
        //{
        //    gameOverManager.showGameOver();
        //}
    }
}
