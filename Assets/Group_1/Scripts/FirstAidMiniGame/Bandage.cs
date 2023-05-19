using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour
{
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private int bandageIndex = 0;
    private int amountBandagesApplied = 0;
    public float minSwipeDistance = 50f;
    public GameObject[] bandage;
    public GameObject[] directionalArrows;
    public GameObject appliedBandage;

    private bool directionSet = false;
    private int direction = 0;
    private int swipedDirection = 0;

    void Start()
    {
        bandage[0].SetActive(false);
        bandage[1].SetActive(false);
        bandage[2].SetActive(false);

        directionalArrows[0].SetActive(false);
        directionalArrows[1].SetActive(false);
        directionalArrows[2].SetActive(false);
        directionalArrows[3].SetActive(false);

        appliedBandage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (amountBandagesApplied < 2)
        {
            if (directionSet)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    swipeStartPos = Input.mousePosition;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    swipeEndPos = Input.mousePosition;
                    if (bandageIndex == 3)
                    {
                        StartCoroutine(CheckBandage());
                    }
                    else
                    {
                        CheckSwipeGesture();
                    }
                }
            }
            else
            {
                RandomizeDirection();
            }
        }
        else
        {
            Debug.Log("Bandages applied!!!!!");
        }
    }

    private void CheckSwipeGesture()
    {
        Vector2 swipeDirection = swipeEndPos - swipeStartPos;

        if (swipeDirection.magnitude >= minSwipeDistance)
        {
            swipeDirection.Normalize();

            // Check the swipe direction
            if (swipeDirection.y > 0.5f)
            {
                Debug.Log("Swipe Up");
                CheckDirection(1);
                // Implement your desired action for swipe up
            }
            else if (swipeDirection.y < -0.5f)
            {
                Debug.Log("Swipe Down");
                CheckDirection(3);
                // Implement your desired action for swipe down
            }
            else if (swipeDirection.x > 0.5f)
            {
                Debug.Log("Swipe Right");
                CheckDirection(2);
                // Implement your desired action for swipe right
            }
            else if (swipeDirection.x < -0.5f)
            {
                Debug.Log("Swipe Left");
                CheckDirection(0);
                // Implement your desired action for swipe left
            }
        }
    }

    public void ResetBandage()
    {
        if (amountBandagesApplied == 1)
        {
            bandageIndex = 0;
            bandage[0].SetActive(false);
            bandage[1].SetActive(false);
            bandage[2].SetActive(false);
            directionalArrows[direction].SetActive(false);
            appliedBandage.SetActive(true);
        }
        else
        {
            bandage[0].gameObject.GetComponent<Renderer>().material.color = Color.red;
            bandage[1].gameObject.GetComponent<Renderer>().material.color = Color.red;
            bandage[2].gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        directionalArrows[direction].SetActive(false);
        directionSet = false;
    }

    public void CheckDirection(int directionInt)
    {
        if (direction == directionInt)
        {
            bandage[bandageIndex].SetActive(true);
            bandageIndex++;
        }
        else
        {
            Debug.Log("WRONG");
        }
        directionalArrows[direction].SetActive(false);
        directionSet = false;
    }

    public void RandomizeDirection()
    {
        direction = Random.Range(0, 4);
        directionalArrows[direction].SetActive(true);
        directionSet = true;
    }

    IEnumerator CheckBandage()
    {
        directionalArrows[direction].SetActive(false);
        yield return new WaitForSeconds(2);
        amountBandagesApplied++;
        ResetBandage();
        StopAllCoroutines();
    }
}
