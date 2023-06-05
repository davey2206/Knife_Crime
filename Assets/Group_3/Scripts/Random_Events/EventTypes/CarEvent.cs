using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvent : MonoBehaviour
{
    [SerializeField] EventManager eventManager = default;
    [SerializeField] PathFollower pathFollower;
    private bool activation = false;

    private void OnEnable()
    {
        eventManager.carEvent += Activation;
    }
    private void OnDisable()
    {
        eventManager.carEvent -= Activation;
    }

    private void Update()
    {
        CarDrives();
    }

    private void CarDrives()
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
