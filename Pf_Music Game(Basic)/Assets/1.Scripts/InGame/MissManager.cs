using UnityEngine;
using UnityEngine.UI;

public class MissManager : MonoBehaviour
{
    public AudioClip missClip;
    public AudioSource missSource;

    [SerializeField]
    GameManager m_mainManager;

    [SerializeField]
    Text infoText;

    void Start()
    {
        missSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            if (m_mainManager.gameOver)
            {
                ScoreManager.missPoint++;

                m_mainManager.playerHp -= 5f;

                Destroy(collision.gameObject);

                missSource.PlayOneShot(missClip);

                infoText.text = "Miss!";
                Invoke("TextInit", 1.5f);
            }
        }
    }

    void TextInit()
    {
        infoText.text = "";
    }
}


