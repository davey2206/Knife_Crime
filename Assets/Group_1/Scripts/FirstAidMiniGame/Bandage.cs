using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bandage : MonoBehaviour
{
    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private int bandageIndex = 0;
    private int amountBandagesApplied = 0;
    private int direction = 0;
    private bool pauseDirection = false;

    public float minSwipeDistance = 50f;
    public float cooldownTime = 1f;
    public GameObject[] bandage;
    public GameObject[] directionalArrows;
    public GameObject appliedBandage;
    public AudioSource audioSource;
    public AudioClip bandageCorrect;
    public AudioClip bandageWrong;

    public bool bandageApplied = false;
    public bool directionSet = false;

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

    public bool StartBandageMiniGame()
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
                CheckSwipeGesture();
            }
        }
        else
        {
            RandomizeDirection();
        }
        return bandageApplied;
    }

    private void CheckSwipeGesture()
    {
        Vector2 swipeDirection = swipeEndPos - swipeStartPos;

        if (swipeDirection.magnitude >= minSwipeDistance && !pauseDirection)
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
        bandageApplied = true;
    }

    public void CheckDirection(int directionInt)
    {
        if (direction == directionInt)
        {
            audioSource.PlayOneShot(bandageCorrect);
            directionalArrows[direction].GetComponent<RawImage>().color = new Color(0.5f, 0.7f, 0.5f);
            if (bandageIndex < 3) bandage[bandageIndex].SetActive(true);
            bandageIndex++;
        }
        else
        {
            audioSource.PlayOneShot(bandageWrong);
            directionalArrows[direction].GetComponent<RawImage>().color = new Color(0.7f, 0.5f, 0.5f);
            Debug.Log("WRONG");
        }

        if (bandageIndex > 2)
        {
            StartCoroutine(CheckBandage());
        }
        else
        {
            StartCoroutine(Cooldown());
        }
    }

    public void RandomizeDirection()
    {
        direction = Random.Range(0, 4);
        directionalArrows[direction].GetComponent<RawImage>().color = Color.gray;
        directionalArrows[direction].SetActive(true);
        directionSet = true;
    }

    IEnumerator CheckBandage()
    {
        pauseDirection = true;
        yield return new WaitForSeconds(cooldownTime);
        directionalArrows[direction].SetActive(false);
        pauseDirection = false;
        amountBandagesApplied++;
        ResetBandage();
        StopAllCoroutines();
    }

    IEnumerator Cooldown()
    {
        pauseDirection = true;
        yield return new WaitForSeconds(cooldownTime);
        directionalArrows[direction].SetActive(false);
        directionSet = false;
        pauseDirection = false;
        StopAllCoroutines();
    }
}
