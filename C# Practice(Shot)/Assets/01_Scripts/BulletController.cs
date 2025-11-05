using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
        //Destroy(gameObject, 2f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}