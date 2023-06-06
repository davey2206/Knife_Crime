using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXHandlerObstacle : MonoBehaviour
{
    [SerializeField] private AudioSource source;    // Source object
    [SerializeField] private AudioClip[] clips;     // Audio clips
    public BoxCollider boxCollider;                 // Collider of obstacle

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")  // Is the player colliding with the obstacle's extended collision?
        {
            int selectedClip = UnityEngine.Random.Range(0, clips.Length);   // Selecting a random clip from array
            source.clip = clips[selectedClip];  // Preparing that clip to play
            source.Play();  // Playing the clip
            // Debug.Log($"Played clip {selectedClip}");
        }
    }
}
