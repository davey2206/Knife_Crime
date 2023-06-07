using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityAction birdEvent;
    public UnityAction carEvent;
    
    [Header("Bird")]
    [SerializeField] private float minBirdActivationTime = 5f;
    [SerializeField] private float maxBirdActivationTime = 10f;
    private float birdTimeLeft;

    [Header("Car")]
    [SerializeField] private float minCarActivationTime = 5f;
    [SerializeField] private float maxCarActivationTime = 10f;
    private float carTimeLeft;

    private void Update()
    {
        CheckBirdRandomEventTime();
        CheckCarRandomEventTime();
    }

    private void CheckBirdRandomEventTime()
    {
        birdTimeLeft -= Time.deltaTime;
        if (birdTimeLeft <= 0f)
        {
            CallBirdEvent();
            birdTimeLeft = SetRandomTime(minBirdActivationTime, maxBirdActivationTime);
        }
    }
    private void CheckCarRandomEventTime()
    {
        carTimeLeft -= Time.deltaTime;
        if (carTimeLeft <= 0f)
        {
            CallCarEvent();
            carTimeLeft = SetRandomTime(minCarActivationTime, maxCarActivationTime);
        }
    }

    private float SetRandomTime(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    private void CallBirdEvent()
    {
        birdEvent?.Invoke();
    }
    private void CallCarEvent()
    {
        carEvent?.Invoke();
    }
}
