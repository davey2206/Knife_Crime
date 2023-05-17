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
    public GameObject appliedBandage;

    void Start()
    {
        bandage[0].SetActive(false);
        bandage[1].SetActive(false);
        bandage[2].SetActive(false);
        appliedBandage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipeEndPos = Input.mousePosition;
            CheckSwipeGesture();
            if (bandageIndex == 3)
            {
                StartCoroutine(CheckBandage());
            }
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
                if(bandageIndex < 3)
                {
                    bandage[bandageIndex].SetActive(true);
                    bandageIndex++;
                }
                // Implement your desired action for swipe up
            }
            else if (swipeDirection.y < -0.5f)
            {
                Debug.Log("Swipe Down");
                //if (bandageIndex > 0)
                //{
                //    bandageIndex--;
                //    bandage[bandageIndex].SetActive(false);
                //}
                // Implement your desired action for swipe down
            }
            else if (swipeDirection.x > 0.5f)
            {
                Debug.Log("Swipe Right");
                // Implement your desired action for swipe right
            }
            else if (swipeDirection.x < -0.5f)
            {
                Debug.Log("Swipe Left");
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
            appliedBandage.SetActive(true);
        }
        else
        {
            bandage[0].gameObject.GetComponent<Renderer>().material.color = Color.red;
            bandage[1].gameObject.GetComponent<Renderer>().material.color = Color.red;
            bandage[2].gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    IEnumerator CheckBandage()
    {
        yield return new WaitForSeconds(2);
        amountBandagesApplied++;
        ResetBandage();
    }
}
