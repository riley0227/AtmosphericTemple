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

    // **NEW: Detect collisions with triggers, such as the temple object**
    private void OnControllerColliderHit(ControllerColliderHit hit)
{
    Debug.Log("Player hit: " + hit.gameObject.name); // Log the object hit

    // Search for the EndGameTrigger component in the parent hierarchy
    EndGameTrigger endGameTrigger = hit.gameObject.GetComponentInParent<EndGameTrigger>();

    if (endGameTrigger != null)
    {
        Debug.Log("End game trigger found! Activating end game screen.");
        endGameTrigger.TriggerEndGame(); // Call the public method
    }
    else
    {
        Debug.LogError("EndGameTrigger component not found in the temple hierarchy!");
    }
}

}
