using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip selectionSound;    
    public AudioMixerGroup mixerGroup;
    
    public void Begin()
    {
        StartCoroutine(BeginSound());
        SceneManager.LoadScene("Luna");
    }

    public void Credits()
    {
        StartCoroutine (CreditsSound());
        SceneManager.LoadScene("Credits");
    }   

    IEnumerator BeginSound()
    {
        AudioManager.Instance.PlaySound(selectionSound, mixerGroup);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator CreditsSound()
    {
        AudioManager.Instance.PlaySound(selectionSound, mixerGroup);
        yield return new WaitForSeconds(2f);
    }

    
}
