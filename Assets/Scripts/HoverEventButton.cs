using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HoverEventButton : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioMixerGroup mixer;

    public void PlayHoverSound()
    {
        AudioManager.Instance.PlaySound(hoverSound, mixer);
    }
}
