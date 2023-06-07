using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    [SerializeField] private string knifeTag;
    [SerializeField] private DamageTracker damageTracker;
    [SerializeField] private int damageValue = 1;


    // want to replace this with some sort of method to measure the intensity of a hit but atm just detects a hit
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(knifeTag))
        {
            Debug.Log("hit");
            damageTracker.DamageUpdate(damageValue);
        }
    }
}
