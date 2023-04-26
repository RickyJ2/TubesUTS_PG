using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    public GameObject specificItem; // The item we want to detect
    public int scoreIncrement = 10; // Amount to increase score when specific item is dropped
    public Text scoreText; // UI Text object to display the score

    private int score = 0; // Current score

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            score += scoreIncrement; // Increase the score
            scoreText.text = "Score: " + score.ToString(); // Update the UI text

            Destroy(collision.gameObject);
        }
    }
}
