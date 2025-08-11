using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;
        private PlayerInput playerInput;

        private CharacterController cc;
        private Vector3 moveInput;

        private float moveSpeed = 2f;
        private float turnSpeed = 10f;

        private void Start()
        {
            anim = GetComponent<Animator>();
            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            cc.Move(moveInput * moveSpeed * Time.deltaTime);
            Turn();
        }

        void OnMove(InputValue value)
        {
            Vector2 move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
        }

        void Turn()
        {
            if (moveInput != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            }
        }
    }
}

