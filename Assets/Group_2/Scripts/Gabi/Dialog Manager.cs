using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actorName;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private RectTransform backgroundBox;

    [SerializeField] private Animator animator;

    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;
    private static bool isActive = false;

    // timer 
    [SerializeField] private float afterDisplayTimer;
    [HideInInspector] private bool startTimer;
    private float timer;
 
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        Debug.Log("Open Dialog");

        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        animator.SetBool("IsOpen", true);
        DisplayMessage();

    }

    public void DisplayMessage()
    {
        Debug.Log("Start");

        //display messages
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.SetText(messageToDisplay.message);

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.SetText(actorToDisplay.name);

        //timer
        
        timer = afterDisplayTimer;
        startTimer = true;

        Debug.Log("End");

    }

    public void NextMessage()
    {
        startTimer = false;
        Debug.Log("next" + startTimer);
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            Debug.Log(activeMessage);
        }else
        {
            Debug.Log("Convo ended");
            animator.SetBool("IsOpen", false);
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive) 
        {
            if (startTimer)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 0;
                    Debug.Log("timer" + startTimer);
                    NextMessage();  // show message after displaying the message + timer
                    
                }

            }
            else { Debug.Log("nahhhh"); }

        }
        
    }
}
