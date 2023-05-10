using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttacks : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !animator.IsInTransition(0))
        {
            animator.Play("Stab");

        }

        if(Input.GetKeyDown(KeyCode.E) && !animator.IsInTransition(0))
        {
            animator.CrossFade("Dodge_Right",0.2f,0);
        }

        if (Input.GetKeyDown(KeyCode.Q) && !animator.IsInTransition(0))
        {
            animator.CrossFade("Dodge_Left", 0.2f,0);
        }
    }
}
