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
        //If player y is below a platform y turn off collider else turn off collider
        if (Player.transform.position.y < transform.position.y)
        {
            colliders.enabled = false;
        }

        //If player y is above a platform y turn on collider else turn on collider
        if (Player.transform.position.y > transform.position.y)
        {
            colliders.enabled = true;
        }

        //If user pushes down then turn off collider
        if (Input.GetAxis("Vertical") < 0)
        {
            colliders.enabled = false;
        }
        
    }
}
