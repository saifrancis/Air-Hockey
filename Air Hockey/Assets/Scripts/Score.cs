using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; 
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text gameResult;
    public int player1Score;
    public int player2Score;
    public Rigidbody2D puckBody;
    public GameObject theButton;
    [SerializeField] private bool isHitByP1;
    [SerializeField] private bool isHitByP2;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // goal scored


        if (collision.CompareTag("Goal1")) // check goal 1
        {
            player2Score++;  // player 2 gets point
            score.text = $"{player1Score} - {player2Score}";
            puckBody.position = Vector2.zero;
            puckBody.velocity = Vector2.zero;
            isHitByP1 = isHitByP2 = false;
            winnerCheck();
        }
        if (collision.CompareTag("Goal2")) // check goal 2
        {
            player1Score++;  // player 2 gets points
            score.text = $"{player1Score} - {player2Score}";
            puckBody.position = Vector2.zero;
            puckBody.velocity = Vector2.zero;
            isHitByP1 = isHitByP2 = false;
            winnerCheck();
        }

        
        // bonus point check by who

        if (collision.CompareTag("Bonus") && isHitByP1) // player 1 check
        {
            player1Score++;
            score.text = $"{player1Score} - {player2Score}";
            winnerCheck();
        }
        if (collision.CompareTag("Bonus") && isHitByP2) // player 2 check
        {
            player2Score++;
            score.text = $"{player1Score} - {player2Score}";
            winnerCheck();
        }
    }

    void winnerCheck()
    {
        // check which player gets 5 points first
        if (player1Score == 5)
        {
            gameResult.text = "YOU WIN!";
            theButton.SetActive(true);
            gameObject.SetActive(false);
        }
        if (player2Score == 5)
        {
            gameResult.text = "YOU ARE A LOSER!";
            theButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void gameReset()
    {
        // reset game to start
        
        player1Score = 0;
        player2Score = 0;
        score.text = $"{player1Score} - {player2Score}";
        gameResult.text = "";
        puckBody.position = Vector2.zero;
        puckBody.velocity = Vector2.zero;
        isHitByP1 = isHitByP2 = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if double hit
        
        if (collision.gameObject.CompareTag("Paddle1"))
        {
            if (isHitByP1) // player 1 check
            {
                if (player1Score > 0 )
                {
                    player1Score--;
                    score.text = $"{player1Score} - {player2Score}";
                }
                
            }
            isHitByP1 = true;
        }
        if (collision.gameObject.CompareTag("Paddle2"))
        {
            if (player2Score>0)
            {
                if (isHitByP2)  // player 2 check
                {
                    player2Score--;
                    score.text = $"{player1Score} - {player2Score}";
                }
            }
           
            isHitByP1 = false;
            isHitByP2 = true;
        }
    }
}
    


