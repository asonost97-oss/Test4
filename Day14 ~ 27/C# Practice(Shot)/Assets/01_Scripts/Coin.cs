using Items;
using UnityEngine;
//using static Item;

public class Coin : Items.Item, IEffect
{
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3f);
                
        Invoke("DestroyThis", 5f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void GetOpaque()
    {
        Color32 color = GetComponent<SpriteRenderer>().color;

        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 50);
    }

    public override void ApplyItem()
    {
        DestroyThis();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }


}
