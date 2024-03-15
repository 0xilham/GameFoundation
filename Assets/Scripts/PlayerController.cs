using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Monitor horizontal keypresses and apply movement to player object
        float hAxis = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(hAxis, 0);
        float speed = 5;

        transform.Translate(direction * Time.deltaTime * speed);
        
        print(hAxis);
    }
}
