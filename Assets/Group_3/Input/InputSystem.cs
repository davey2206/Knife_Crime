using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void Jump(InputAction.CallbackContext context) // Activates three times since phase is not defined here, Started, performed & canceled.
    {
        // Define phase
        if(context.performed)
        {
            Debug.Log("Jump " + context.phase);
            playerRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
