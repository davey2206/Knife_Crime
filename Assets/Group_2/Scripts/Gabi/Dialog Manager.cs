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

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        animator.SetBool("IsOpen", true);
        DisplayMessage();
    }

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.SetText(messageToDisplay.message);

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.SetText(actorToDisplay.name);

    }

    public void NextMessage()
    {
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
        if(Input.GetKeyDown(KeyCode.Space) && isActive) 
        {

            NextMessage();
        }
        
    }
}
