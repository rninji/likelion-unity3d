using System.Collections;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("EnterIdle");
        StartCoroutine(MethodA());
    }

    public void StateUpdate()
    {
        Debug.Log("UpdateIdle");
    }

    public void StateExit()
    {
        Debug.Log("ExitIdle");
    }

    IEnumerator MethodA()
    {
        Debug.Log("MethodA");
        yield return null;
    }
}
