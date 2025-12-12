using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinaEnemy : MonoBehaviour
{
    [SerializeField] private float movDist;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;


    private void Awake()
    {
        leftEdge = transform.position.x - movDist;
        rightEdge = transform.position.x + movDist;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (movingLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }


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
