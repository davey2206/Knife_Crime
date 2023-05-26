using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEvent : MonoBehaviour
{
    [SerializeField] EventManager eventManager = default;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    [SerializeField] float speed = 10;
    [SerializeField] [Range(0, 2)] int eventNumber;
    private bool activation = false;
    private bool reverse = false;

    private void Awake()
    {
        startPos = transform.position;
        endPos = transform.position;
        endPos.x += 10;
    }

    private void OnEnable()
    {
        eventManager.birdEvent += BirdActivation;
    }
    private void OnDisable()
    {
        eventManager.birdEvent -= BirdActivation;
    }

    private void Update()
    {
        BirdFlies();
    }

    private void BirdFlies()
    {
        if (!activation) return;        
        if (!reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);
            if (transform.position == endPos)
            {
                activation = false; 
                ChangeDirection();
            }
        }
        else if (reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
            if (transform.position == startPos)
            {
                activation = false; 
                ChangeDirection();
            }
        }
        
    }

    private void ChangeDirection()
    {
        reverse = !reverse;
    }

    private void BirdActivation(int value)
    {
        Debug.Log("the eventNumber for bird is: " + value);
        if (value == eventNumber)
        {
            activation = true;
        }        
    }
}
