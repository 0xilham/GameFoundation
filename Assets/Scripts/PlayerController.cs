using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float hAxis;
    Vector2 direction;

    [SerializeField]
    float speed = 3;

    Rigidbody rb;
    [SerializeField]
    float jumpPowerSetup = 5;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Monitor horizontal keypresses and apply movement to player object
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);


        transform.Translate(direction * Time.deltaTime * speed);

        //If spacaebar is pressed then apply velocity to rb on y axis
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 1) * jumpPowerSetup;
        }   
        
    }
}
