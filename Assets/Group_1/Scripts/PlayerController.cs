using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AnimationsControllerTest animationsController;
    [SerializeField] GameObject target;
    [SerializeField] Camera cam;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
