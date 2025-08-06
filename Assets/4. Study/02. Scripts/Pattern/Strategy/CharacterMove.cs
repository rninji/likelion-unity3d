using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // public enum MoveState { Walk, Run, FLy }
    //
    // public MoveState moveState = MoveState.Walk;
    //
    // public float walkSpeed, runSpeed, flySpeed;

    private IMovement movement;

    private void Start()
    {
        movement = new MoveFly(3f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            movement = new MoveWalk(3f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            movement = new MoveRun(5f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            movement = new MoveWalk(10f);
        }
        movement.Move(transform);
    }

    void Move()
    {
        // switch (moveState)
        // {
        //     case MoveState.Walk:
        //         transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        //         break;
        //     case MoveState.Run:
        //         transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        //         break;
        //     case MoveState.FLy:
        //         transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
        //         break;
        // }
        
        movement.Move(transform);
    }
}
