using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text musicNameText;

    [SerializeField]
    AudioClip[] backMusicClips;

    AudioSource backAudio;

    [SerializeField]
    Slider playerHpSlider;
    public float playerHp = 100f;
    public bool isGameOver = true;

    void Start()
    {
        backAudio = GetComponent<AudioSource>();

        backAudio.clip = backMusicClips[SelectManager.musicNum];

        backAudio.Play();

        musicNameText.text = "Music : " + SelectManager.musicName;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            playerHpSlider.value = playerHp;

            if (playerHp <= 0f)
            {
                isGameOver = false;

                SceneManager.LoadScene("Result");
            }
        }
    }
}
