using UnityEngine;

public class WolfFollow : MonoBehaviour
{
    public Transform dog; // Assign the dog's Transform in the Inspector
    public float followSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate direction to the dog
        Vector3 direction = (dog.position - transform.position).normalized;

        // Move towards the dog
        Vector3 newPosition = rb.position + direction * followSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        // Rotate to face the dog
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, toRotation, Time.fixedDeltaTime * 10f));
        }
    }
}
