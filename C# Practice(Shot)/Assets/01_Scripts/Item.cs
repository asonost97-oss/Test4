using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        SpriteRenderer sr;

        public abstract void DestroyAfterTime();

        public abstract void ApplyItem();

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();

            DestroyAfterTime();

        }
    }    
}

public interface IEffect
{
    void GetOpaque();
}

public enum EItems
{
    Coin, SpeedUp, PowerUp
}