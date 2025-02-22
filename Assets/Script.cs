using UnityEngine;

public class DogController : MonoBehaviour
{
    public float moveSpeed = 5f; // Forward/backward movement speed
    public float strafeSpeed = 3f; // Lateral movement speed
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        // Get components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get player input
        float verticalInput = Input.GetAxis("Vertical"); // W/S for forward/backward
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D for strafing

        // Create a movement vector
        Vector3 moveDirection = new Vector3(horizontalInput * strafeSpeed, 0, verticalInput * moveSpeed);

        // Move the Rigidbody
        Vector3 newPosition = rb.position + moveDirection * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        // Update animation based on speed
        float speed = moveDirection.magnitude;
        animator.SetFloat("Speed", speed);

        // Rotate the dog to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, toRotation, Time.fixedDeltaTime * 10f));
        }
    }
}
