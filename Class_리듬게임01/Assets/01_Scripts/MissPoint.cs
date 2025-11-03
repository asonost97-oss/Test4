using UnityEngine;


public class MissPoint : MonoBehaviour
{
    AudioClip missClip;
    AudioSource missSource;

    [SerializeField]
    MainManager m_mainManager;
    
    void Start()
    {
        missSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Point")
        {
            if(m_mainManager.isGameOver)
            {
                m_mainManager.playerHp -= 5f;

                Destroy(collision.gameObject);

                missSource.PlayOneShot(missClip);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
