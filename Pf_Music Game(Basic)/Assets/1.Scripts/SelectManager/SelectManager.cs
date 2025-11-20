using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour, IVolumeSetting
{
    AudioSource audioSource;

    [SerializeField] 
    AudioClip[] audioClip;

    [SerializeField]
    Slider slider;

    [SerializeField]
    GameObject[] musicSelects;

    [SerializeField]
    int selectNum = 0;

    public static string musicName;

    public static int musicNum = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        selectNum = 0;

        audioSource.PlayOneShot(audioClip[musicNum]);

        for(int i = 0; i < musicSelects.Length; i++)
        {
            musicSelects[i].SetActive(false);
        }

        if(musicSelects.Length > 0)
        {
            musicSelects[0].SetActive(true);
        }

        if (audioClip != null && audioClip.Length > 0)
        {
            // musicNum이 유효한 범위인지 확인
            if (musicNum >= 0 && musicNum < audioClip.Length)
            {
                selectNum = musicNum;
                // 이전에 선택했던 음악 UI 활성화
                if (selectNum < musicSelects.Length)
                {
                    musicSelects[selectNum].SetActive(true);
                }
                audioSource.PlayOneShot(audioClip[musicNum]);
            }
            else
            {
                // 유효하지 않으면 첫 번째 음악 재생
                if (audioClip[0] != null)
                {
                    audioSource.PlayOneShot(audioClip[0]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyVolume(float linear)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(linear);
        }
    }

    public void MusicBtn(string btn)
    {
        if(btn == "RightButton")
        {
            audioSource.Stop();

            musicSelects[selectNum].SetActive(false);

            selectNum++;

            musicSelects[selectNum].SetActive(true);

            audioSource.PlayOneShot(audioClip[selectNum]);

            if (selectNum < audioClip.Length && audioClip[selectNum] != null)
            {
                audioSource.PlayOneShot(audioClip[selectNum]);
            }
        }
        else if(btn == "LeftButton")
        {
            if(selectNum > 0)
            {
                audioSource.Stop();

                musicSelects[selectNum].SetActive(false) ;

                selectNum--;

                musicSelects[selectNum].SetActive(true) ;

                audioSource.PlayOneShot(audioClip[selectNum]);

                if (selectNum >= 0 && selectNum < audioClip.Length && audioClip[selectNum] != null)
                {
                    audioSource.PlayOneShot(audioClip[selectNum]);
                }
            }
        }
    }

    public void LoadingBtn()
    {
        musicNum = selectNum;

        musicName = musicSelects[selectNum].transform.GetChild(1).GetComponent<Text>().text;

        SceneManager.LoadScene("Loading");
    }
}
