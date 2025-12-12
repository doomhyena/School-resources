using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Double")
        {
            if (collision.collider.tag == "Double")
                player.GetComponent<playerMovement>().isDoubled = true;

            player.GetComponent<playerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // ugrás hogy ne tudjon kettöt ugrani
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Double")
        {
            if (collision.collider.tag == "Double")
                player.GetComponent<playerMovement>().isDoubled = false;

            player.GetComponent<playerMovement>().isGrounded =false;
        }
    }
}
