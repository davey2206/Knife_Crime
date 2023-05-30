using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;

public class EventManager : MonoBehaviour
{
    public UnityEvent<IEventType> randomEvent;

    [SerializeField] private List<IEventType> events;
    [SerializeField] private Transform transformEventsParent;

    private void Start()
    {
        GetChildrenWithInterface();
    }

    private void GetChildrenWithInterface()
    {
        List<Transform> children = new List<Transform>();
        List<Transform> temp = new List<Transform>();
        foreach (Transform transform in transformEventsParent)
        {
            Debug.Log(transform.name);
            children.Add(transform);
        }
    }
}
