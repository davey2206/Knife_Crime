using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsControllerTest : MonoBehaviour
{

    private Animator animator;
    private FullBodyBipedIK iK;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        iK = GetComponent<FullBodyBipedIK>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(stab());
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DodgeLeft());

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DodgeRight());

        }

    }

    public IEnumerator DodgeLeft()
    {
        if (isPlaying) { yield break; }
        isPlaying = true;
        Vector3 startPos = transform.position;
        animator.Play("Dodge_Left");

        const float length = 1.4f;
        float currentTime = 0;
        float weight = 1f;
        const float dodgeApex = 0.5f;
        const int speedFactor = 80;


        while (currentTime <= dodgeApex)
        {
            transform.position += new Vector3(-1/weight,0,0) / speedFactor;

            weight += currentTime * 2;
            currentTime += Time.deltaTime;
            yield return null;
        }

        Vector3 dodgeReturn = (startPos - transform.position) / (length - currentTime);

        while (currentTime <= length)
        {
            transform.position += dodgeReturn * Time.deltaTime;
            if(transform.position.x > startPos.x) { transform.position = startPos; }
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos + new Vector3(0, 0.01f, 0);
        isPlaying = false;
    
}

    public IEnumerator DodgeRight()
    {
        if (isPlaying) { yield break; }
        isPlaying = true;
        Vector3 startPos = transform.position;
        animator.Play("Dodge_Right");

        const float length = 1.4f;
        float currentTime = 0;
        float weight = 1f;
        const float dodgeApex = 0.5f;
        const int speedFactor = 80;


        while (currentTime <= dodgeApex)
        {
            transform.position += new Vector3(1 / weight, 0, 0) /speedFactor;

            weight += currentTime * 2;
            currentTime += Time.deltaTime;
            yield return null;
        }

        Vector3 dodgeReturn = (startPos - transform.position) / (length - currentTime);

        while (currentTime <= length)
        {
            transform.position += dodgeReturn * Time.deltaTime;
            if (transform.position.x < startPos.x) { transform.position = startPos; }
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos + new Vector3(0,0.01f,0);
        isPlaying = false;

    }

    public IEnumerator stab()
    {
        if(isPlaying) { yield break; }
        isPlaying = true;
        Vector3 startPos = transform.position;
        animator.Play("Stab");

        const float length = 2f;
        float currentTime = 0;
        float weight = 0;
        const float stabApex = 0.5f;
        const float stabReturn = 1f;
        const int returnSpeedFactor = 8;


        while(currentTime <= stabApex) //wind up to final stab location
        {
            iK.solver.SetEffectorWeights(FullBodyBipedEffector.RightHand,weight,0);

            weight = currentTime * 2;
            currentTime += Time.deltaTime;
            yield return null;
        }

        while(currentTime <= stabReturn)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }

        while(currentTime <= length)
        {
            iK.solver.SetEffectorWeights(FullBodyBipedEffector.RightHand,weight,0);
            
            if(weight > 0) weight -= Time.deltaTime * returnSpeedFactor; 
            currentTime += Time.deltaTime;
            yield return null;
        }
        isPlaying = false;
        transform.position = startPos + new Vector3(0, 0.007f, 0);
    }
}
