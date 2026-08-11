using UnityEngine;

public class SoundAPI : MonoBehaviour
{
    public static SoundAPI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShotSound(GameObject go, AudioClip clip, float volume)
    {
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = 1.0f;
        source.Play();
        Destroy(source, clip.length);
    }

    public void PlayRandomSound(GameObject go, AudioClip[] audioClips, float volume)
    {
        int index = Random.Range(0, audioClips.Length);
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = audioClips[index];
        source.volume = volume;
        source.spatialBlend = 1.0f;
        source.Play();
        Destroy(source, audioClips[index].length);
    }
}
