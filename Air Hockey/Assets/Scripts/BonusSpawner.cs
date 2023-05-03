using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    private float countdown = 3;
    public GameObject bonusThing; 

    void Update()
    {
        // randomly spwans bonus point at intervals of 3
        countdown = countdown - Time.deltaTime;
        Vector2 bonusPos = new Vector2(Random.Range(-8,8), Random.Range(-3,3));
           
        if (countdown <= 0)
        {
            Instantiate(bonusThing, bonusPos, Quaternion.identity);
            Debug.Log("spawn"); 
            countdown = 3; 
        }
      
    }
}
