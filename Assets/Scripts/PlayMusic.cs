using UnityEngine;
using UnityEngine.Audio;

public class PlayMusic : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float musicVolume = 0.5f;

    public AudioMixerGroup musicBus;
    
    private AudioSource musicAudioSource;

    public AudioClip musicClip;
    //public float musicVolume = 0.8f;
    public bool musicLoop = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.outputAudioMixerGroup = musicBus;
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = musicLoop;
        musicAudioSource.volume = musicVolume;
        musicAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
