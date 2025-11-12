using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 50f;
    public float speed;

    public float Health
    {
        get { return health; }
    }

    void TakeDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float ratio)
    {
        health -= (int)(health * ratio);

        if(health <= 0) 
        {
            Die();
        }
    }

    //public float GetHealth()
    //{
    //    return health;
    //}

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);

            Debug.Log("health: " + health);

            collision.gameObject.SetActive(false);
        }
    }    

    public virtual void Move()
    {

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
