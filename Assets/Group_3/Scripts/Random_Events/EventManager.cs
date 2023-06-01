using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;

public class EventManager : MonoBehaviour
{
    public UnityAction<int> birdEvent;
    public UnityAction<int> carEvent;
    
    [Header("Bird")]
    [SerializeField] private float minBirdActivationTime = 5f;
    [SerializeField] private float maxBirdActivationTime = 10f;
    [SerializeField]
    [Range(0, 2)] private int birdEventAmount;
    private float birdTimeLeft;

    [Header("Car")]
    [SerializeField] private float minCarActivationTime = 5f;
    [SerializeField] private float maxCarActivationTime = 10f;
    [SerializeField]
    [Range(0, 2)] private int carEventAmount;
    private float carTimeLeft;


    private void Start()
    {
    }

    private void Update()
    {
        CheckBirdRandomEventTime();
        CheckCarRandomEventTime();
    }

    private void CheckBirdRandomEventTime()
    {
        birdTimeLeft -= Time.deltaTime;
        if (birdTimeLeft <= 0)
        {
            CallBirdEvent();
            birdTimeLeft = SetRandomTime(minBirdActivationTime, maxBirdActivationTime);
        }
    }
    private void CheckCarRandomEventTime()
    {
        carTimeLeft -= Time.deltaTime;
        if (carTimeLeft <= 0)
        {
            CallCarEvent();
            birdTimeLeft = SetRandomTime(minCarActivationTime, maxCarActivationTime);
        }
    }

    private float SetRandomTime(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    private void CallBirdEvent()
    {
        birdEvent?.Invoke(birdEventAmount);
    }
    private void CallCarEvent()
    {
        carEvent?.Invoke(carEventAmount);
    }
}
