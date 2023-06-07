using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AnimationsControllerTest animationsController;
    [SerializeField] GameObject target;
    [SerializeField] Camera cam;
    [SerializeField] GameObject head;

    private bool hitIgnore = true;
    
    public void ignoreNextHit()
    {
        if (hitIgnore)
        {
            hitIgnore = false;
        }
        else
        {
            hitIgnore = true;
        }
    }

    void Update()
    {
        cam.transform.position = head.transform.position + new Vector3(0, 1, 0);

        if (Input.GetMouseButtonDown(0) && !hitIgnore)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if(objectHit.CompareTag("targetting plane"))
                {
                    target.transform.position = hit.point;
                    StartCoroutine(animationsController.stab());
                }
            }
        }
        else if(Input.GetMouseButtonDown(0) && hitIgnore)
        {
            hitIgnore = false;
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(animationsController.DodgeLeft());
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(animationsController.DodgeRight());
        }

    }
}
