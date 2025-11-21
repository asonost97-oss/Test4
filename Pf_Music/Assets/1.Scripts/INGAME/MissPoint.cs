using UnityEngine;
using UnityEngine.UI;

public class MissPoint : MonoBehaviour
{
    public AudioClip missClip;
    public AudioSource missSource;

    [SerializeField]
    Text infoText;

    private void Start()
    {
        missSource = GetComponent<AudioSource>();

        if (missSource != null)
        {
            missSource.playOnAwake = false;  // 자동 재생 비활성화
            missSource.loop = false;  // 반복 재생 비활성화
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Note")))
        {
            missSource.PlayOneShot(missClip);

            infoText.text = "Miss!";
            Invoke("TextInit", 0.5f);
        }
    }

    void TextInit()
    {
        infoText.text = "";
    }
}
