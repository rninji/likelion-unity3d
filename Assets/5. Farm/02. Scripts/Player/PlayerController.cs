using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private const float GRAVITY = -9.8f;
        
        private Animator anim;
        private CharacterController cc;
        
        private Vector3 moveInput;
        private bool isRun;

        private float currentSpeed;
        private float walkSpeed = 2f;
        private float runSpeed = 5f;
        private float turnSpeed = 10f;
        private Vector3 velocity;

        private void Awake()
        {
            int characterIndex = LoadSceneManager.Instance.characterIndex;
            transform.GetChild(characterIndex).gameObject.SetActive(true);
            anim = transform.GetChild(characterIndex).GetComponent<Animator>();
            
            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            velocity.y += GRAVITY;
            var dir = moveInput * currentSpeed + Vector3.up * velocity.y;
            cc.Move(dir * Time.deltaTime);
            SetAnimation();
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

        void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }

        void SetAnimation()
        {
            float targetValue = 0;

            if (moveInput != Vector3.zero)
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }

            float animValue = anim.GetFloat("Move");
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);

            anim.SetFloat("Move", animValue);
        }
    }
}

