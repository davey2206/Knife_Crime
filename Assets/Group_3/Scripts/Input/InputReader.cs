using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    public GameInput gameInput { get; private set; }
    public event UnityAction<Vector3> movementEvent;
    public event UnityAction<Vector2> mouseEvent;
    public event UnityAction jumpEvent;
    public event UnityAction interactEvent;
    public event UnityAction escapeEvent;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
        }
        EnableGameplay();
    }
    private void OnDisable()
    {
        DisableGameplay();
    }

    private void DisableGameplay() => gameInput.Gameplay.Disable();

    public void EnableGameplay()
    {
        gameInput.Gameplay.Enable();
        gameInput.Gameplay.SetCallbacks(this);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            escapeEvent?.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jumpEvent?.Invoke();
        }
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        mouseEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementEvent?.Invoke(context.ReadValue<Vector3>());
    }
}
