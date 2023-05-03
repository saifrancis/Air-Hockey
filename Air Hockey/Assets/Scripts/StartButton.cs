using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject puck;
    public Score score;
    private float countdown = 3;
    private bool isCountdowning = false;
    public GameObject theButton;
    public TMP_Text countdownClock; 

    private void Update()
    {
        if (isCountdowning) //start when button pressed
        {
            countdown = countdown - Time.deltaTime;
            countdownClock.text = $"{(int)countdown + 1}"; 
            if (countdown <= 0) // if countdown is 0
            {
                puck.SetActive(true);
                score.gameReset();
                isCountdowning = false;
                countdownClock.text = ""; 
            }
        }  
    }
    public void buttonPress()
    {
        // start and reset countdown
        isCountdowning = true;
        countdown = 3;
        theButton.SetActive(false); 
    }
}
