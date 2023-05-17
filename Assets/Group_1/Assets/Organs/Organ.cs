using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    [SerializeField] private string organName;
    [SerializeField] private int hitPoints = 1;
    [SerializeField] private int hits = 0;


    // want to replace this with some sort of method to measure the intensity of a hit but atm just detects a hit
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if(collision.collider.CompareTag("knife"))
        {
            hitPoints--;
            hits++;
            if(hitPoints < 0)
            {
                hitPoints = 0;
                hits--;
            }
            Debug.Log("knife hit on " + organName + " registered. hitpoints: " + hitPoints + ", hits: " + hits);
        }
    }

    public int GetHitpoints()
    {
        return hitPoints;
    }

    public int GetHits()
    {
        return hits;
    }

    public string GetOrganName()
    {
        return organName;
    }
}
