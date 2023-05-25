using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidNavigation : MonoBehaviour
{
    public GameObject bandageControls;
    public GameObject firstAidUI;
    public GameObject directions;
    public GameObject miniGameController;

    public bool AtStartOfGame { get; private set; } = true;

    void Start()
    {
        firstAidUI.SetActive(false);
    }

    public void CloseBandageControls()
    {
        bandageControls.SetActive(false);
        firstAidUI.SetActive(true);
        directions.SetActive(true);
        miniGameController.SetActive(true);
        Time.timeScale = 1.0f;
        AtStartOfGame = false;
    }

    public void OpenBandageControls()
    {
        bandageControls.SetActive(true);
        firstAidUI.SetActive(false);
        directions.SetActive(false);
        miniGameController.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void GameStarted()
    {
        AtStartOfGame = false;
    }
}
