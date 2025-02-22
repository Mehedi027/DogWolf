using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class TreasureCollector : MonoBehaviour
{
    private int treasureCount = 0; // Counter for collected treasures
    public Text treasureCounterText; // Reference to the UI Text component

    private void Start()
    {
        // Initialize the treasure counter display at the start of the game
        if (treasureCounterText != null)
        {
            treasureCounterText.text = "Treasures: 0";
        }
        else
        {
            Debug.LogError("TreasureCounterText is not assigned in the Inspector!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "Treasure"
        if (other.CompareTag("Treasure"))
        {
            // Increment the treasure count
            treasureCount++;

            // Update the treasure counter display
            if (treasureCounterText != null)
            {
                treasureCounterText.text = "Treasures: " + treasureCount;
            }

            // Remove the treasure object from the scene
            Destroy(other.gameObject);

            // Optional: Debug message for testing
            Debug.Log("Treasure Collected! Total Treasures: " + treasureCount);
        }
    }
}
