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
        float horizontalAxis = Input.GetAxis("Horizontal");
        
        Input.GetAxis("Horizontal");
        
        print(horizontalAxis);
    }
}
