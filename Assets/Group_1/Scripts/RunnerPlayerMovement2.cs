using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerPlayerMovement2 : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private float sourcePitch;

    void Start()
    {
        // Assign a random Pitch value between 0.9 and 1.1 (non-inclusive); Default playback is 1
        sourcePitch = UnityEngine.Random.Range(0.9f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x !< 3.2)
            {
                PlayWhooshSound();
                StartCoroutine(Move(true));
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x !> -3.2)
            {
                PlayWhooshSound();
                StartCoroutine(Move(false));
            }

        }
    }

    private void PlayWhooshSound()
    {
        source.Play();  // Play the whoosh sound
        sourcePitch = UnityEngine.Random.Range(0.9f, 1.1f); // Assign new random value for Pitch
        source.pitch = sourcePitch; // Apply it to audio source
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GetComponent<SceneChanger>().changeScene();
        }
    }

    IEnumerator Move(bool dir)
    {
        for (int i = 0; i < 15; i++)
        {
            if (dir)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
