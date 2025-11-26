using UnityEngine;

public class Effect : MonoBehaviour
{
    public float life = 1;
    
    void Start()
    {
        Destroy(this.gameObject, life);
    }
}
