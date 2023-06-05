using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEvent : MonoBehaviour
{
    [SerializeField] EventManager eventManager = default;
    [SerializeField] PathFollower pathFollower;
    private bool activation = false;

    private void OnEnable()
    {
        eventManager.birdEvent += Activation;
    }
    private void OnDisable()
    {
        eventManager.birdEvent -= Activation;
    }

    private void Update()
    {
        BirdFlies();
    }

    private void BirdFlies()
    {
        if (!activation) return;
        pathFollower.ResetDistanceTravelled();
        activation = false;
        
    }

    public void Activation()
    {
            activation = true;        
    }
}
