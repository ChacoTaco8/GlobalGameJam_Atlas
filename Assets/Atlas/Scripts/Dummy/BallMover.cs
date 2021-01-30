using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class BallMover : MonoBehaviour
{
    public CharacterController ball;
    private Controls controls;
    private float speed = 0.175f;
    private Vector3 direction;
    private bool isJumping = false;

    public void SetDirection(InputAction.CallbackContext context)
    {
        Vector2 normalizedDirection = context.ReadValue<Vector2>().normalized;
        direction = new Vector3(normalizedDirection.x, 0, normalizedDirection.y) * speed;
    }

    public void Jump()
    {
        ball.Move(Vector3.up);
    }
    
    private void Start()
    {
        if (ball == null) ball = GetComponent<CharacterController>();
        controls = new Controls();
    }

    private void Update()
    {
        ball.Move(direction);
        if (controls.CharacterController.Jump.enabled)
        {
            
        }
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.CharacterController.Jump.Enable();
        controls.CharacterController.Movement.Enable();
        controls.CharacterController.Interact.Enable();
    }
}
