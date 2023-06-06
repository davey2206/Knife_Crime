using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    [SerializeField] private string knifeTag;
    [SerializeField] private DamageTracker damageTracker;

    private bool invincible = false;
    private float invincibilityTime = 1;

    // want to replace this with some sort of method to measure the intensity of a hit but atm just detects a hit
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(knifeTag) && !invincible)
        {
            Debug.Log("hit");
            damageTracker.DamageUpdate();
            invincible = true;
        }
    }

    // invincibility timer to stop a single stab from being registered multiple times
    private void Update()
    {
        if (invincible)
        {
            invincibilityTime = invincibilityTime - Time.deltaTime;
            if(invincibilityTime <= 0)
            {
                invincible = false;
                invincibilityTime = 1;
            }
        }
    }
}
