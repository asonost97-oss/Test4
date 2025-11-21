using UnityEngine;

public class Spawn : MonoBehaviour
{
    Rigidbody2D rb;

    public float leftForce = 5f; // 좌측으로 가할 힘의 크기

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = Random.Range(5, 13);

        // 좌측으로 힘을 가함
        rb.AddForce(Vector2.left * leftForce, ForceMode2D.Impulse);
    }
}
