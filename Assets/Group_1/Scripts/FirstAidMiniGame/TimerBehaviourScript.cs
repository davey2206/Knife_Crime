using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerBehaviourScript : MonoBehaviour
{

    TextMeshProUGUI timerMesh;
    [SerializeField] int timerLength; //in seconds
    [SerializeField] float stressModifier = 0.1f;
    [SerializeField] float stressCap = 0.0f; //keep below 0.1 to be effective

    public GameObject gameOverScreen;
    public GameObject tourniquetGame;
    public GameObject bandageGame;
    public AudioSource audioSource;
    public AudioClip heartbeat;
    private bool heartbeatEnabled = false;

    float time;
    float currentStressMod;
    
    bool running;

    public void set(int timeInSec)
    {
        time = timeInSec;
    }
    public void start()
    {
        running = true;
        gameOverScreen.SetActive(false);
    }
    public void stop()
    {
        running = false;
    }
    public void resetStress()
    {
        currentStressMod = 0;
    }



    // Start is called before the first frame update
    void Start()
    {
        timerMesh = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        time = timerLength;
        running = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
        {
            currentStressMod += (Time.deltaTime * stressModifier);
            if (currentStressMod > stressCap && stressCap!=0.0f) currentStressMod = stressCap;
            time -= (Time.deltaTime + currentStressMod);

            if (time < 0) time = 0;

            if (time < 60)
            {
                if (!heartbeatEnabled)
                {
                    heartbeatEnabled = true;
                    audioSource.clip = heartbeat;
                    audioSource.pitch = 1f;
                    audioSource.Play();
                }
                GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>().color = Color.red;
            }

            if(time > 20 && time < 40) audioSource.pitch = 1.5f;
            if(time > 10 && time < 20) audioSource.pitch = 2f;
            if(time > 0 && time < 10) audioSource.pitch = 3f;

            timerMesh.text = Mathf.FloorToInt(time / 60).ToString("00") + ":" + (time % 60).ToString("00.000");
        
            if(time==0)
            {
                running = false;
                Debug.Log("GAME OVER");
                gameOverScreen.SetActive(true);
                tourniquetGame.SetActive(false);
                bandageGame.SetActive(false);
                audioSource.Stop();
                //add gameover call here
            }
        }
    }
}
