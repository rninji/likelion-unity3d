using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 5f;
    private Vector2 moveInput;
    
    void Start()
    {
        var dir = new Vector3(moveInput.x, 0, moveInput.y);
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        cc.Move(moveInput * speed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        bool isJump = value.isPressed;
        Debug.Log("Jump");   
    }
    
    void OnInteraction(InputValue value)
    {
        Debug.Log(value.isPressed);   
    }
    
    void OnAttack(InputValue value)
    {
        
        Debug.Log("Attack");   
    }
}
