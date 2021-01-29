using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class BallMover : MonoBehaviour
{
    public CharacterController ball;

    
    private float speed = 0.175f;
    private Vector3 direction;

    public void SetDirection(InputAction.CallbackContext context)
    {
        Vector2 normalizedDirection = context.ReadValue<Vector2>().normalized;
        direction = new Vector3(normalizedDirection.x, 0, normalizedDirection.y) * speed;
    }

    private void Start()
    {
        if (ball == null) ball = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ball.Move(direction);
    }
}
