using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    Score scoreScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the apple collides with the player
        if (collision.tag == "Player")
        {
            // Add score
            scoreScript.AddScore();

            // Destroy the apple
            Destroy(this.gameObject);
        }
    }
}
