using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //When player tag enters trigger restart scene
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Level1");
            print("Player has fallen");
        }
    }
}
