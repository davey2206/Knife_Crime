using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public event UnityAction<int> birdEvent;
    public event UnityAction<int> carEvent;
    public event UnityAction<int> helicopterEvent;

    [Header("bird")]
    [SerializeField] private float minimumBirdActivationTime = 10f;
    [SerializeField] private float maximumBirdActivationTime = 15f;
    private float birdTimeLeft;

    [Header("car")]
    [SerializeField] private float minimumCarActivationTime = 10f;
    [SerializeField] private float maximumCarActivationTime = 15f;
    private float carTimeLeft;

    [Header("helicopter")]
    [SerializeField] private float minimumHelicopterActivationTime = 10f;
    [SerializeField] private float maximumHelicopterActivationTime = 15f;
    private float helicopterTimeLeft;

    private void Update()
    {
        CheckBirdActivationTime();
        CheckCarActivationTime();
        CheckHelicopterActivationTime();
    }

    private void CheckBirdActivationTime()
    {
        birdTimeLeft -= Time.deltaTime;
        if (birdTimeLeft <= 0)
        {
            CallBirdEvent();
            birdTimeLeft = SetRandomTime(minimumBirdActivationTime, maximumBirdActivationTime);
        }
    }

    private void CheckCarActivationTime()
    {
        carTimeLeft -= Time.deltaTime;
        if (carTimeLeft <= 0)
        {
            CallCarEvent();
            carTimeLeft = SetRandomTime(minimumCarActivationTime, maximumCarActivationTime);
        }
    }

    private void CheckHelicopterActivationTime()
    {
        helicopterTimeLeft -= Time.deltaTime;
        if (helicopterTimeLeft <= 0)
        {
            CallHelicopterEvent();
            helicopterTimeLeft = SetRandomTime(minimumHelicopterActivationTime, maximumHelicopterActivationTime);
        }
    }

    private float SetRandomTime(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    private void CallBirdEvent()
    {
        birdEvent?.Invoke(Random.Range(0, 2));
    }
    private void CallCarEvent()
    {
        carEvent?.Invoke(Random.Range(0, 2));
    }
    private void CallHelicopterEvent()
    {
        helicopterEvent?.Invoke(Random.Range(0, 2));
    }
}
