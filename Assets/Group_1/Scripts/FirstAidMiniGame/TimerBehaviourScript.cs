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
    void Update()
    {
        if (running)
        {
            currentStressMod += (Time.deltaTime * stressModifier);
            if (currentStressMod > stressCap && stressCap!=0.0f) currentStressMod = stressCap;
            time -= (Time.deltaTime + currentStressMod);

            if (time < 0) time = 0;
            timerMesh.text = Mathf.FloorToInt(time / 60).ToString("00") + ":" + (time % 60).ToString("00.000");
        
            if(time==0)
            {
                running = false;
                Debug.Log("GAME OVER");
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
                //add gameover call here
            }
        }
    }
}
