using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float hAxis;
    Vector2 direction;

    [SerializeField]
    float speed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Monitor horizontal keypresses and apply movement to player object
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);
        speed = 5;

        transform.Translate(direction * Time.deltaTime * speed);
        
        print(hAxis);
    }
}
