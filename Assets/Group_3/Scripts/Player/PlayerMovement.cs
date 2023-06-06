using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource source;    // Source object
    [SerializeField] private AudioClip[] clips;     // Audio clips
    [SerializeField] private float stepRate;        // Default - 0.3f; do not set lower than 0.1f, will clip early

    private float time;
    private int index;
    private float pitchVariation;

    [SerializeField] InputReader inputReader = default;
    [SerializeField] private StatsSO stats;
    private Vector3 position = new Vector3();
    private Vector3 lastPosition = new Vector3();
    private new Rigidbody rigidbody;
    private Transform cam;


    private void OnEnable()
    {
        inputReader.movementEvent += OnMove;
    }
    private void OnDisable()
    {
        inputReader.movementEvent -= OnMove;
    }

    private void Start()
    {
        time = 0f;
        index = UnityEngine.Random.Range(0, clips.Length);  // Assign random footstep sound
        pitchVariation = 1f;
        lastPosition = Vector3.zero;

        cam = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        Move();
        Rotate();
        PlayStep();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * position.z + cam.right * position.x;
        rigidbody.MovePosition(transform.position + dir * stats.MovementSpeed * Time.deltaTime);
    }
    private void Rotate()
    {
        transform.rotation = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up);
    }

    //Event System
    private void OnMove(Vector3 value)
    {
        position = value;
    }

    private void PlayStep()
    {
        if (time > stepRate && 
            (Math.Round(lastPosition.x, 2) != Math.Round(rigidbody.position.x, 2)) &&   // I have to round it to 2 digits only
            (Math.Round(lastPosition.z, 2) != Math.Round(rigidbody.position.z, 2)))     // Because the position keeps changing VERY slightly
        {
            lastPosition = rigidbody.position;
            time = 0f;

            // Footstep sound core
            source.clip = clips[index]; // Load the footstep sound
            source.pitch = pitchVariation; // Adjust pitch
            source.Play();  // Play the sound
            index = UnityEngine.Random.Range(0, clips.Length);  // Reassign footstep sound
            pitchVariation = UnityEngine.Random.Range(0.8f, 1.2f);  // Reassign Pitch
        }
    }
}
