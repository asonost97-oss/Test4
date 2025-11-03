using UnityEngine;

public class Spawn : MonoBehaviour
{
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = Random.Range(5, 13);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
