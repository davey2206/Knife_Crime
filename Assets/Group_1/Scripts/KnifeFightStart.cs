using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFightStart : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject fight;
    [SerializeField] GameObject deathUI;
    [SerializeField] GameObject winUI;

    public void FightStart()
    {
        fight.SetActive(true);
        startUI.SetActive(false);
        deathUI.SetActive(false);
    }

    public void FightWin()
    {
        fight.SetActive(false);
        winUI.SetActive(true);
        // #######################################
        // put scene swap to next scene here Davey
        // #######################################
    }

    public void FightLose()
    {
        fight.SetActive(false);
        deathUI.SetActive(true);
    }

}
