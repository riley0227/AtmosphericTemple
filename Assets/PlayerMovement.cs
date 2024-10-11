using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;

    private CharacterController characterController;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Handle movement
        float move = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 moveDirection = new Vector3(move, 0f, 0f);

        // Apply gravity and check if grounded
        if (characterController.isGrounded)
        {
            velocity.y = -2f; // Small value to keep grounded state

            // Jump if grounded and 'W' is pressed
            if (Input.GetKeyDown(KeyCode.W))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; // Apply gravity when not grounded
        }

        // Move the character
        characterController.Move((moveDirection + velocity) * Time.deltaTime);
    }
}
