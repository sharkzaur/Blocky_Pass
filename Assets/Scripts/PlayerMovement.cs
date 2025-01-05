using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouseX_NewInputSystem : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float speed = 10f; // Adjust the speed multiplier for movement sensitivity

    private Vector2 previousMousePosition; // Store the previous mouse position
    private bool isSliding;               // Track if the "Slide" action is active

    private void Update()
    {
        if (isSliding)
        {
            // Get the current mouse position
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();

            // Calculate the delta (change) in mouse position
            float deltaX = currentMousePosition.x - previousMousePosition.x;

            // Move the Rigidbody based on the mouse movement direction
            Vector3 movement = new Vector3(deltaX * speed * Time.deltaTime, 0, 0);
            Rigidbody.MovePosition(Rigidbody.position + movement);

            // Update the previous mouse position
            previousMousePosition = currentMousePosition;
        }
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Begin sliding and initialize the previous mouse position
            isSliding = true;
            previousMousePosition = Mouse.current.position.ReadValue();
        }
        else if (context.canceled)
        {
            // Stop sliding
            isSliding = false;
        }
    }
}