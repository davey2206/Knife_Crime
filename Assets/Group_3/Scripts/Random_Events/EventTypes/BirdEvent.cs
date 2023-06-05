using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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
        
        
    }

    public void Activation()
    {
            activation = true;        
    }
}
