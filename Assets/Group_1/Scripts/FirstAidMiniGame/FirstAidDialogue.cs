using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidDialogue : MonoBehaviour
{
    public AudioClip[] dialogue;
    public AudioSource audioSource;
    public int dialogueContinuation = 0;
    public bool audioIsPlaying = false;
    
    public float PlayDialogue()
    {
        audioSource.Stop();
        audioIsPlaying = true;
        audioSource.PlayOneShot(dialogue[dialogueContinuation]);

        return dialogue[dialogueContinuation].length;
    }

    public void NextDialogue()
    {
        dialogueContinuation++;
    }

    public void RepeatDialogue()
    {
        if (!audioIsPlaying)
        {
            audioSource.Stop();
            audioIsPlaying = true;
            audioSource.PlayOneShot(dialogue[dialogueContinuation]);
            StartCoroutine(WaitForAudioToEnd(dialogue[dialogueContinuation].length));
        }
    }

    IEnumerator WaitForAudioToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioIsPlaying = false;
    }
}
