using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidNavigation : MonoBehaviour
{
    public GameObject bandageControls;

    public bool AtStartOfGame { get; private set; } = true;

    public void CloseBandageControls()
    {
        bandageControls.SetActive(false);
        Time.timeScale = 1.0f;
        AtStartOfGame = false;
    }

    public void OpenBandageControls()
    {
        bandageControls.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void GameStarted()
    {
        AtStartOfGame = false;
    }
}
