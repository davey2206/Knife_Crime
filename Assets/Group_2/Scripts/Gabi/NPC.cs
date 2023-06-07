using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]private DialogTrigger trigger;

    private void Start()
    {
        trigger.StartDialogue();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        trigger.StartDialogue();
    //    }
    //}

}
