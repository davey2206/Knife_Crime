using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidDialogue : MonoBehaviour
{
    public AudioClip[] dialogue;
    public AudioSource audioSource;
    public int dialogueContinuation = 0;
    
    public void PlayDialogue()
    {
        audioSource.PlayOneShot(dialogue[dialogueContinuation]);
    }

    public void NextDialogue()
    {
        dialogueContinuation++;
    }
}
