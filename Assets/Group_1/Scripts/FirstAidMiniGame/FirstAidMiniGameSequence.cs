using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidMiniGameSequence : MonoBehaviour
{
    public GameObject bandageControls;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseBandageControls()
    {
        bandageControls.SetActive(false);
    }
}
