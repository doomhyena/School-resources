using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);
            collision.GetComponent<playerMovement>()
                .GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0, 0), ForceMode2D.Impulse);
        }
    }

    
}
