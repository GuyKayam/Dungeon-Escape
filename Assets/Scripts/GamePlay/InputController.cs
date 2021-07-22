using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[System.Serializable]
public  class MoveInputEvent : UnityEvent<float, float> { }

[System.Serializable]
public class ShootInputEvent : UnityEvent<float, float> { }

[System.Serializable]
public class DropBomb : UnityEvent { }

[System.Serializable]
public class ShootInputStopped : UnityEvent { }

public class InputController : MonoBehaviour
{
    Controls controls;

    [SerializeField]
     MoveInputEvent moveInputEvent;
    [SerializeField]
    ShootInputEvent shootInputEvent;
    [SerializeField]
     ShootInputStopped shootInputStopped;
    [SerializeField]
    DropBomb droppedBomb;



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
        controls.GamePlay.Shoot.performed += OnShootingBtnPressed;
        controls.GamePlay.Shoot.canceled += OnShootingBtnReleased;
        controls.GamePlay.DropBomb.started += OnDropBomb;


        //controls.GamePlay.Shoot.canceled += OnShootformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        moveInputEvent?.Invoke(movementInput.x, movementInput.y);
    }

    private void OnShootingBtnPressed(InputAction.CallbackContext context)
    {
        Vector2 shootingInput = context.ReadValue<Vector2>();
        shootInputEvent?.Invoke(shootingInput.x, shootingInput.y);
    }
    private void OnShootingBtnReleased(InputAction.CallbackContext context)
    {
        shootInputStopped?.Invoke();
    }

    private void OnDropBomb(InputAction.CallbackContext context)
    {
        droppedBomb?.Invoke();
    }


}
