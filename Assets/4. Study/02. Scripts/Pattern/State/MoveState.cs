using UnityEngine;

public class MoveState : MonoBehaviour, IState 
{
    public void StateEnter()
    {
        Debug.Log("EnterMove");
    }

    public void StateUpdate()
    {
        Debug.Log("UpdateMove");
    }

    public void StateExit()
    {
        Debug.Log("ExitMove");
    }
}
