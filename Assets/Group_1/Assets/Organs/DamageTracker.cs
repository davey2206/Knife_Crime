using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTracker : MonoBehaviour
{
    [SerializeField] private int hitpoints = 5;
    [SerializeField] private bool player = false;
    [SerializeField] private KnifeFightStart UIManager;
    private int realHitpoints;

    private void OnEnable()
    {
        realHitpoints = hitpoints;
    }

    public void DamageUpdate()
    {
        realHitpoints--;
        if(realHitpoints <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if(player)
        {
            UIManager.FightLose();
        }
        else
        {
            UIManager.FightWin();
        }
    }





    //public int GetOrganHitpoints(string organName)
    //{
    //    return GetOrgan(organName).GetHitpoints();
    //}

    //public int GetOrganHits(string organName)
    //{
    //    return GetOrgan(organName).GetHits();
    //}

    //public Organ GetOrgan(string organName)
    //{
    //    foreach (Organ o in organs)
    //    {
    //        if (o.GetOrganName() == organName)
    //        {
    //            return o;
    //        }
    //    }
    //    Debug.Log("Organ with name: " + organName + " not found");
    //    return null;
    //}

    //void Start()
    //{
    //    foreach (Organ o in GetComponentsInChildren<Organ>(true))
    //    {
    //        Debug.Log(o.GetOrganName() + " added to damage tracker");
    //        organs.Add(o);
    //    }
    //}
}
