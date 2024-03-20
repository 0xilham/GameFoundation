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

    Rigidbody2D rb;
    [SerializeField]
    bool onGround = false;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Facing();
        Animations();
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

    void Facing()
    {
        //If player is moving left then flip sprite to face left scale x = -1
        if (hAxis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //If player is moving right then flip sprite to face right scale = 1
        if (hAxis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Animations()
    {
        //If player is moving then play running animation
        animator.SetFloat("Moving", Mathf.Abs(hAxis));
        animator.SetBool("OnGround", onGround);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        //if trigger enter object with tag "ground" then onGround is true
        if (col.tag == "ground")
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //if trigger exit object with tag "ground" then onGround is false
        if (col.tag == "ground")
        {
            onGround = false;
        }
    }
}
