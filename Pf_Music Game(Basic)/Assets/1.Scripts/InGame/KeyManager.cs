using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    AudioSource keyAudio;

    [SerializeField]
    AudioClip clickClip;
    [SerializeField]
    Color[] keyColors;
    [SerializeField]
    Image[] keyPointsImages;

    public bool[] isKeyPut;

    void Start()
    {
        keyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isKeyPut[0] = true;
            keyAudio.PlayOneShot(clickClip);

            keyPointsImages[0].color = keyColors[0];
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isKeyPut[0] = false;

            keyPointsImages[0].color = new Color(1, 1, 1, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isKeyPut[1] = true;
            keyAudio.PlayOneShot(clickClip);

            keyPointsImages[1].color = keyColors[1];
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isKeyPut[1] = false;

            keyPointsImages[1].color = new Color(1, 1, 1, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isKeyPut[2] = true;
            keyAudio.PlayOneShot(clickClip);

            keyPointsImages[2].color = keyColors[2];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isKeyPut[2] = false;

            keyPointsImages[2].color = new Color(1, 1, 1, 0.5f);
        }
    }
}
