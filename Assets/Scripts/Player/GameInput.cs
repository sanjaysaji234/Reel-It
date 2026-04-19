using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions=new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
   
    public bool IsSpacePressed()
    {
        return playerInputActions.Player.Jump.WasPressedThisFrame();
    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
}
