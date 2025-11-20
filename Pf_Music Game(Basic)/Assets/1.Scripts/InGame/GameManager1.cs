using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    [SerializeField]
    AudioSource backAudioSource;
    [SerializeField]
    AudioSource keyAudioSource;

    [SerializeField]
    Slider backSlider;
    [SerializeField]
    Slider keySlider;
    [SerializeField]
    GameObject gameAudioUI;
  
    void Update()
    {
        backAudioSource.volume = backSlider.value;
        keyAudioSource.volume = keySlider.value;

        if (gameAudioUI.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;

                backAudioSource.Pause();

                keyAudioSource.Pause();

                gameAudioUI.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;

                backAudioSource.UnPause();

                keyAudioSource.UnPause();

                gameAudioUI.SetActive(false);
            }
        }
        
    }
}
