using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform rodEnd;
    [SerializeField] LayerMask Ground;
    [SerializeField] private GameInput gameInput;
    public bool blockCast=false;
    public enum playerState
    {
        Idle,
        Waiting,
        Bite,
        Reeling,
        Result
    };
    public playerState currentState=playerState.Idle;

    private void Update()
    {
        if (blockCast)
        {
            blockCast = false;
            return;
        }

        switch (currentState)
        {
            case playerState.Idle:
                if (gameInput.IsSpacePressed())
                {
                    HandleWaiting();
                }
                break;   
            case playerState.Waiting:
                if (gameInput.IsSpacePressed())
                {
                    currentState = playerState.Idle;
                }
                break;
            case playerState.Reeling:
                
                break;
            case playerState.Result:
                break;
        }

    }

   
    private void HandleWaiting()
    {
        currentState=playerState.Waiting;

    }
}
