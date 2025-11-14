using Items;
using UnityEngine;
//using static Item;

public class SpeedUp : Items.Item, IEffect
{
    SpriteRenderer sr;

    public override void DestroyAfterTime()
    {
        Invoke("DestroyThis", 5f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void GetOpaque()
    {
        Color32 color = sr.color;

        sr.color = new Color32(color.r, color.g, color.b, 50);
    }

    public override void ApplyItem()
    {
        GameObject playerobj = GameObject.Find("Player");

        PlayerController controller = playerobj.GetComponent<PlayerController>();

        controller.speed *= 1.25f;

        DestroyThis();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
