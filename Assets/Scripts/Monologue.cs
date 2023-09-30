using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    public AudioClip dialogue1;
    public AudioClip dialogue2;
    public AudioClip dialogue3;
    public AudioClip dialogue4;
    public AudioClip dialogue5;

    IEnumerator BeginDialogs()
    {
        AudioManager.Instance.PlaySound(dialogue1);
        yield return new WaitForSeconds(11f);
        AudioManager.Instance.PlaySound(dialogue2);
        yield return new WaitForSeconds(13f);
        AudioManager.Instance.PlaySound(dialogue3);
        yield return new WaitForSeconds(6f);
        AudioManager.Instance.PlaySound(dialogue4);
        yield return new WaitForSeconds(4f);
        AudioManager.Instance.PlaySound(dialogue5);
        yield return new WaitForSeconds(5f);
    }

    public void Dialogs()
    {
        StartCoroutine(BeginDialogs());
    }
}
