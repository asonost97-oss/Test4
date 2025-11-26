using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;  // ½Ì±ÛÅæ

    AudioSource myAudio;

    public AudioClip[] attackSound; // ¹è¿­
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
