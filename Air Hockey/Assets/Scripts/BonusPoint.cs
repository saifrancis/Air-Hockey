using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoint : MonoBehaviour
{
    private float countdown = 3;

    void Update()
    {
        // ensure the bonus point disappears after 3sec
        countdown = countdown - Time.deltaTime;
        if (countdown <= 0)
        {
            Destroy(gameObject);
            countdown = 3;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destorys if puck hits
        if (collision.CompareTag("Puck"))
        {
            Destroy(gameObject); 
        }
    }
}
