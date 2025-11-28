using UnityEngine;

public class Enemy2 : Enemy
{
    private void Start()
    {
        Move();
    }

    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
    }
}
