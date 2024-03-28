using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    BoxCollider2D colliders;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jika pemain berada di bawah platform, matikan collider
        if (Player.transform.position.y < transform.position.y)
        {
            colliders.enabled = false;
        }
        // Jika pemain berada di atas platform, hidupkan collider
        else if (Player.transform.position.y > transform.position.y)
        {
            colliders.enabled = true;
        }

        // Jika pemain berada di samping kiri atau kanan platform, matikan collider
        if (Player.transform.position.x < transform.position.x || Player.transform.position.x > transform.position.x)
        {
            colliders.enabled = false;
        }
    }
}
