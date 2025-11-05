using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource backGroundAudio;
    [SerializeField]
    AudioSource keySoundAudio;

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
        keySoundAudio.volume = keySlider.value;  // value를 넣어서 소리 조절

        if(gameAudioUI.activeSelf == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;

                gameAudioUI.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape) )
            {
                Time .timeScale = 1f;

                gameAudioUI.SetActive(false);
            }
        }
    }
}
