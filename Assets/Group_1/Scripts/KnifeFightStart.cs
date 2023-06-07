using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFightStart : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject fight;
    [SerializeField] GameObject deathUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameToggle gameToggle;
    [SerializeField] SceneChanger sceneChanger;

    public void FightStart()
    {
        gameToggle.ToggleGame(true);
        startUI.SetActive(false);
        deathUI.SetActive(false);
    }

    public void FightWin()
    {
        gameToggle.ToggleGame(false);
        winUI.SetActive(true);
    }

    public void FightLose()
    {
        gameToggle.ToggleGame(false);
        deathUI.SetActive(true);
    }

    public void EndFight()
    {
        sceneChanger.changeScene();
    }

}
