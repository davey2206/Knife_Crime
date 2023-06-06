using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidMiniGameSequence : MonoBehaviour
{
    public GameObject firstAidNavigation;
    public GameObject dialogue;
    public GameObject applyingBandages;
    public GameObject applyingTourniquet;
    public GameObject tourniquetScript;
    public GameObject timerObject;
    public GameObject victoryScreen;
    public GameObject tourniquetObject;
    private float audioDuration;

    public bool SequenceIsActive { get; private set; } = false;
    public int SequenceNumber { get; private set; }

    // 1. Controls
    // 2. Dialogue
    // 3. Apply bandage
    // 4. dialogue
    // 5. apply another bandage
    // 6. dialogue
    // 7. controls tourniquet
    // 8. apply tourniquet

    // Start is called before the first frame update
    void Start()
    {
        firstAidNavigation.GetComponent<FirstAidNavigation>().OpenBandageControls();
        SequenceNumber++;

        applyingTourniquet.SetActive(false);
        timerObject.SetActive(false);
        victoryScreen.SetActive(false);
        tourniquetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstAidNavigation.GetComponent<FirstAidNavigation>().AtStartOfGame && !SequenceIsActive)
        {
            switch (SequenceNumber)
            {
                case 1:
                    TriggerDialogue();
                    timerObject.SetActive(true);
                    break;
                case 2:
                    if (applyingBandages.GetComponent<Bandage>().StartBandageMiniGame())
                    {
                        dialogue.GetComponent<FirstAidDialogue>().NextDialogue();
                        SequenceNumber++;
                        applyingBandages.GetComponent<Bandage>().bandageApplied = false;
                        applyingBandages.GetComponent<Bandage>().directionSet = false;
                    }
                    break;
                case 3:
                    TriggerDialogue();
                    break;
                case 4:
                    if (applyingBandages.GetComponent<Bandage>().StartBandageMiniGame())
                        SequenceNumber++;
                    break;
                case 5:
                    dialogue.GetComponent<FirstAidDialogue>().NextDialogue();
                    TriggerDialogue();
                    break;
                case 6:
                    //Playing is false in StartTourniquetMiniGame function that's why it's a "!" in the if-statement
                    applyingTourniquet.SetActive(true);
                    if (!tourniquetScript.GetComponent<TourniquetIndicatorBehaviour>().StartTourniquetMiniGame())
                    {
                        tourniquetObject.SetActive(true);
                        timerObject.SetActive(false);
                        victoryScreen.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void TriggerDialogue()
    {
        SequenceIsActive = true;
        audioDuration = dialogue.GetComponent<FirstAidDialogue>().PlayDialogue();
        StartCoroutine(WaitForAudioToEnd(audioDuration));
    }

    IEnumerator WaitForAudioToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        dialogue.GetComponent<FirstAidDialogue>().audioIsPlaying = false;
        SequenceNumber++;
        SequenceIsActive = false;
    }
}
