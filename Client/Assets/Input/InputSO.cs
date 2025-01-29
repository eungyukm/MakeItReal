using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SO/InputSO", fileName = "InputSO")]
public class InputSO : ScriptableObject
{
    public InputSystem InputSystem;

    public UnityAction<Vector2> moveAction;
    public UnityAction<Vector2> lookActin;
    
    private void OnEnable()
    {
        InputSystem = new InputSystem();
        InputSystem.InGame.Enable();
        
        // 입력 Mapping
        InputSystem.InGame.Move.performed += ctx => moveAction.Invoke(ctx.ReadValue<Vector2>());
        InputSystem.InGame.Move.canceled += ctx => moveAction?.Invoke(Vector2.zero);
        
        // 입력 마우스
        InputSystem.InGame.Look.performed += ctx => lookActin.Invoke(ctx.ReadValue<Vector2>());
        InputSystem.InGame.Look.canceled += ctx => lookActin.Invoke(Vector2.zero);
    }

    private void OnDisable()
    {
        // 입력 Mapping Disalbe
        InputSystem.InGame.Move.performed -= ctx => moveAction.Invoke(ctx.ReadValue<Vector2>());
        InputSystem.InGame.Move.canceled -= ctx => moveAction?.Invoke(Vector2.zero);
        
        // 입력 마우스 Disalbe
        InputSystem.InGame.Look.performed -= ctx => lookActin.Invoke(ctx.ReadValue<Vector2>());
        InputSystem.InGame.Disable();
    }
}
