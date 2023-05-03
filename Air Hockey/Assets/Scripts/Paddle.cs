using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera cam;
    public Rigidbody2D paddle1;
    public float moveSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; //gets camera 
    }

    // Update is called once per frame
    void Update()
    {

        //gets mouse pos in world 

        Vector2 worldPos; 
        Vector2 mousePos = Input.mousePosition;
        worldPos = cam.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y)); 
        
        //find the vector towards the mouse 
        Vector2 paddleToMouse; 
        paddleToMouse = worldPos - paddle1.position;
        paddle1.velocity = paddleToMouse.normalized * moveSpeed;

        //when mouse inside circle, stays still
        if (paddleToMouse.magnitude < transform.localScale.x /2)
        {
            paddle1.velocity = Vector2.zero; 
        }

        //keep player1 paddle on left 
        if (paddle1.position.x > 0)
        {
            paddle1.position = new Vector2(0, paddle1.position.y);
        }





    }
}

