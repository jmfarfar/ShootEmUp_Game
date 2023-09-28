using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] private AudioSource backgroundMusic;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(this);
        }

        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySound(AudioClip clip, AudioMixerGroup mixer = null)
    {
        if (mixer == null)
            audioSource.PlayOneShot(clip);
        else
        {
            audioSource.PlayOneShot(clip);
            audioSource.outputAudioMixerGroup = mixer;
        }
    }

    public void PlayAmbiental(AudioClip clip)
    {
        backgroundMusic.PlayOneShot(clip);
    }
}
