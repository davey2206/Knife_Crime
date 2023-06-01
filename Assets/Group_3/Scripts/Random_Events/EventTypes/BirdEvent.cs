using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BirdEvent : MonoBehaviour
{
    [SerializeField] EventManager eventManager = default;
    [SerializeField] PathFollower pathFollower;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    [SerializeField] float speed = 10;
    [SerializeField] [Range(0, 2)] int eventNumber;
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

    public void Activation(int index)
    {
        if (index == eventNumber)
        {
            activation = true;
        }
    }
}
