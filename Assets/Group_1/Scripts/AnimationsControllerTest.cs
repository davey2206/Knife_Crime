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
        if(Input.GetMouseButtonDown(0) && !isPlaying)
        {
            animator.Play("Stab");
            StartCoroutine(stab());
            isPlaying = true;
        }

    }

    IEnumerator stab()
    {
        const float length = 2f;
        float currentTime = 0;
        float weight = 0;
        const float stabApex = 0.5f;
        const float stabReturn = 1f;


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
            
            if(weight > 0) weight -= Time.deltaTime * 10; 
            currentTime += Time.deltaTime;
            yield return null;
        }
        isPlaying = false;
    }
}
