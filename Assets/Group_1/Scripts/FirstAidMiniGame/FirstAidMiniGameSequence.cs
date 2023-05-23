using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidMiniGameSequence : MonoBehaviour
{
    public GameObject firstAidNavigation;
    public GameObject dialogue;
    public int sequenceNumber = 1;

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
        sequenceNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        switch (sequenceNumber)
        {
            case 2:
                
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                Debug.Log("Apply Tourniquet");
                break;
            default:
                break;
        }
    }
}
