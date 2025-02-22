using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with is an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle collision with an obstacle (e.g., stop or bounce)
            Debug.Log("Collided with an obstacle!");

            // Example: Apply a small force to the character to bounce off slightly
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply an impulse force to simulate a bounce
                rb.AddForce(-collision.contacts[0].normal * 5f, ForceMode.Impulse);
            }
        }
    }
}
