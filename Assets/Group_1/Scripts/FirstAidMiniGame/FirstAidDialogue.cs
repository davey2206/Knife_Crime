using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidDialogue : MonoBehaviour
{
    public AudioClip[] dialogue;
    public AudioSource audioSource;
    public int dialogueContinuation = 0;
    
    public float PlayDialogue()
    {
        audioSource.PlayOneShot(dialogue[dialogueContinuation]);

        return dialogue[dialogueContinuation].length;
    }

    public void NextDialogue()
    {
        dialogueContinuation++;
    }
}
