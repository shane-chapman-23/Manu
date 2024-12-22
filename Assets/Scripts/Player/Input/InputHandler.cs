using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Vector2 _rawMovementInput;
    public int NormInputX { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        _rawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int)(_rawMovementInput * Vector2.right).normalized.x;
    }
}
