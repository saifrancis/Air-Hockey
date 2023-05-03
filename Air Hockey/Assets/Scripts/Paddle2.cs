using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public GameObject puck;
    public float paddleSpeed;
    public Rigidbody2D paddle2Body;

    // Update is called once per frame
    void Update()
    {
        //get possition of puck 
        //get possition of paddle 
        

        // get pos for puck and paddle
        Vector2 puckPos;
        Vector2 paddle2Pos;
        puckPos = puck.transform.position;
        paddle2Pos = transform.position;

        if (puckPos.x > 0) //determine whether puck is on right side 
        {
            // paddle follows puck            
            var target = puckPos; 
            var paddleToTarget = target - paddle2Pos; // vector the paddle needs to move
            var direction = paddleToTarget.normalized;
            var velocity = paddleSpeed * direction;
            paddle2Body.velocity = velocity; 
        }
        else // when puck on left
        {
            // stays inline with puck at a distance

            var target = new Vector2(5.5f, puckPos.y);
            var paddleToTarget = target - paddle2Pos;  // vector the paddle needs to move
            var direction = paddleToTarget.normalized;
            var velocity = paddleSpeed * direction;
            paddle2Body.velocity = velocity;

        }

        // ensures that paddle2 stays on the right
        if (transform.position.x < 0)
        {
            transform.position = new Vector2(0, transform.position.y);
        }

    }
}
