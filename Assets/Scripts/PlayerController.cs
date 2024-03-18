using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float hAxis;
    Vector2 direction;

    [SerializeField]
    float speed = 3;
    [SerializeField]
    float jumpPower = 5;

    Rigidbody rb;
    [SerializeField]
    bool onGround = false;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        //Monitor horizontal keypresses and apply movement to player object
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);

        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        //If spacaebar is pressed then apply velocity to rb on y axis
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.velocity = new Vector2(0, 1) * jumpPower;
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        //if trigger enter object with tag "ground" then onGround is true
        if (col.tag == "ground")
        {
            onGround = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        //if trigger exit object with tag "ground" then onGround is false
        if (col.tag == "ground")
        {
            onGround = false;
        }
    }
}
