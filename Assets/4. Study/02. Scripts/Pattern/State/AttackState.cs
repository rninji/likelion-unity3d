using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("EnterAttack");
    }

    public void StateUpdate()
    {
        UnityEngine.Debug.Log("UpdateAttack");
    }

    public void StateExit()
    {
        Debug.Log("ExitAttack");
    }
}
