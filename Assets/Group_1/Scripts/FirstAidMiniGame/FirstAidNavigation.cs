using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidNavigation : MonoBehaviour
{
    public GameObject bandageControls;

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
        Time.timeScale = 1.0f;
    }

    public void OpenBandageControls()
    {
        bandageControls.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RepeatDialogue()
    {

    }
}
