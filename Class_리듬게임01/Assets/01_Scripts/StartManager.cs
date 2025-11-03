using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public AudioSource playerAudio;

    [SerializeField]
    AudioClip[] selectAudioClips;

    [SerializeField]
    int selecNum;

    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    GameObject[] musicSelects;

    public static string musicName;
    public static int musicNum;

    public void MusicBtn(string btnName)
    {
        if(btnName == "NextBtn")
        {
            playerAudio.Stop();

            musicSelects[selecNum].SetActive(false);

            selecNum++;

            musicSelects[selecNum].SetActive(true);

            playerAudio.PlayOneShot(selectAudioClips[selecNum]);
        }        
        else
        {
            if(selecNum > 0)
            {
                playerAudio.Stop();

                musicSelects[selecNum].SetActive(false);

                selecNum--;

                musicSelects[selecNum].SetActive(true);

                playerAudio.PlayOneShot(selectAudioClips[selecNum]);
            }
        }
    }

    

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        playerAudio.PlayOneShot(selectAudioClips[musicNum]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
