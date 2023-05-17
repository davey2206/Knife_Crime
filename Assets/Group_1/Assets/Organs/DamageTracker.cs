using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTracker : MonoBehaviour
{
    [SerializeField] private List<Organ> organs = new List<Organ>();

    private void OnCollisionExit(Collision collision)
    {
        DamageUpdate();
    }

    private void DamageUpdate()
    {
        // to fill in logic on damage threshholds eg if brain has hit 0 hitpoint that person loses immediately
    }

    public int GetOrganHitpoints(string organName)
    {
        return GetOrgan(organName).GetHitpoints();
    }

    public int GetOrganHits(string organName)
    {
        return GetOrgan(organName).GetHits();
    }

    public Organ GetOrgan(string organName)
    {
        foreach(Organ o in organs)
        {
            if(o.GetOrganName() == organName)
            {
                return o;
            }
        }
        Debug.Log("Organ with name: " + organName + " not found");
        return null;
    }

    void Start()
    {
        foreach(Organ o in GetComponentsInChildren<Organ>(true))
        {
            Debug.Log(o.GetOrganName() + " added to damage tracker");
            organs.Add(o);
        }
    }



    
}
