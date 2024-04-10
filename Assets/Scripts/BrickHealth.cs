using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrickHealth : MonoBehaviour
{
    public int brickHealth = 3; // Initial health of the brick
    public int scoreValue = 10; // Score value to add when the brick is destroyed
    private TextMeshProUGUI hitCounterText;

    void Start()
    {
        hitCounterText = GetComponentInChildren<TextMeshProUGUI>();

        if (hitCounterText != null)
        {
            UpdateBrickHealth();
        }
        else
        {
            Debug.LogError("TMP component not found!");
        }
    }

    private void UpdateBrickHealth()
    {
        hitCounterText.text = brickHealth.ToString();
    }

// This method is called when a 2D collider enters the trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding GameObject has a Bullet tag
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // Subtract 1 from bulletHealth
            brickHealth--;
            UpdateBrickHealth();

            // Check if bulletHealth has reached 0
            if (brickHealth <= 0)
            {
                // Add scoreValue to the player's score
                //GameManager.instance.AddScore(scoreValue);

                // Destroy the brick GameObject
                Destroy(gameObject);
            }
        }
    }
}