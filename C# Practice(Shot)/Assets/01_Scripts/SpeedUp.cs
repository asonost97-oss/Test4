using UnityEngine;

public class SpeedUp : Item
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyThis", 5f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    public override void ApplyItem()
    {
        
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
