using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[System.Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }

[System.Serializable]
public class ShootInputEvent : UnityEvent<float, float> { }

public class InputController : MonoBehaviour
{
    Controls controls;

    public MoveInputEvent moveInputEvent;
    public ShootInputEvent shootInputEvent;


    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.GamePlay.Enable();
        controls.GamePlay.Move.performed += OnMovePerformed;
        controls.GamePlay.Move.canceled += OnMovePerformed;
        //controls.GamePlay.Shoot.performed += OnShootformed;
        controls.GamePlay.Shoot.started += OnShootformed;

        //controls.GamePlay.Shoot.canceled += OnShootformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(movementInput.x, movementInput.y);
    }

    private void OnShootformed(InputAction.CallbackContext context)
    {
        Vector2 shootingInput = context.ReadValue<Vector2>();
        shootInputEvent.Invoke(shootingInput.x, shootingInput.y);
    }


}
