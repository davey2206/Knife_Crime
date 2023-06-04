using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    [SerializeField] private string knifeTag;
    [SerializeField] private DamageTracker damageTracker;


    // want to replace this with some sort of method to measure the intensity of a hit but atm just detects a hit
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit 1");
        if(collision.collider.CompareTag(knifeTag))
        {
            damageTracker.DamageUpdate();
            Debug.Log("knife hit registered");
        }
    }
}
