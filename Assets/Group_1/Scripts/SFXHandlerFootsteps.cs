using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandlerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioSource source;    // Source object
    [SerializeField] private AudioClip[] clips;     // Audio clips
    [SerializeField] private float stepRate;    // Default - 0.3f; do not set lower than 0.1f, will clip early
    [SerializeField] private float timeLimit;
    private float time;
    private float timeClamped;
    private int index;
    private float pitchVariation;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeClamped = 0f;
        index = UnityEngine.Random.Range(0, clips.Length);  // Assign random footstep sound
        pitchVariation = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ((time < timeLimit) && (Math.Round(time, 2) > (timeClamped + stepRate))) {
            timeClamped = (float)Math.Round(time, 2);

            // Footstep sound core
            source.clip = clips[index]; // Load the footstep sound
            source.pitch = pitchVariation; // Adjust pitch
            source.Play();  // Play the sound
            index = UnityEngine.Random.Range(0, clips.Length);  // Reassign footstep sound
            pitchVariation = UnityEngine.Random.Range(0.8f, 1.2f);  // Reassign Pitch
        }
        
        //Debug.Log($"Elapsed: {time} (real) - {timeClamped} (clamped) | Index: {index} | Pitch: {pitchVariation}");
    }
}
