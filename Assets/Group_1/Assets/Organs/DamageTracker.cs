using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTracker : MonoBehaviour
{
    [SerializeField] private int hitpoints = 5;
    [SerializeField] private bool player = false;
    [SerializeField] private KnifeFightStart UIManager;

    private int realHitpoints;

    private bool invincible = false;
    private float invincibilityTime = 1;

    private void Awake()
    {
        realHitpoints = hitpoints;
    }

    private void Update()
    {
        if (invincible)
        {
            invincibilityTime = invincibilityTime - Time.deltaTime;
            if (invincibilityTime <= 0)
            {
                invincible = false;
                invincibilityTime = 1;
            }
        }
    }

    public void DamageUpdate(int damageValue)
    {
        if(!invincible)
        {
            invincible = true;
            hitpoints -= damageValue;
            if (hitpoints <= 0)
            {
                EndGame();
            }
        }
        
    }

    public void ResetHitpoints()
    {
        hitpoints = realHitpoints;
    }

    private void EndGame()
    {
        Debug.Log("game ended");
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
