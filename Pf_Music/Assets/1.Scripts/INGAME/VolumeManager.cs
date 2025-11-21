using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    AudioSource backGroundAudio;
    [SerializeField]
    AudioSource missSound;
    [SerializeField]
    AudioSource tapSound;

    [SerializeField]
    Slider backSlider;
    [SerializeField]
    Slider keySlider;
    [SerializeField]
    GameObject gameAudioUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        backGroundAudio.volume = backSlider.value;

        missSound.volume = keySlider.value;  // value를 넣어서 소리 조절

        tapSound.volume = keySlider.value;

        if (gameAudioUI.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;

                gameAudioUI.SetActive(true);

                PauseMusic();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;

                gameAudioUI.SetActive(false);

                ResumeMusic();
            }
        }
    }

    // 노래 일시정지
    private void PauseMusic()
    {
        if (backGroundAudio != null && backGroundAudio.isPlaying)
        {
            backGroundAudio.Pause();
            Debug.Log("배경 음악 일시정지");
        }
    }

    // 노래 재개
    private void ResumeMusic()
    {
        if (backGroundAudio != null)
        {
            backGroundAudio.UnPause();
            Debug.Log("배경 음악 재개");
        }
    }
}
