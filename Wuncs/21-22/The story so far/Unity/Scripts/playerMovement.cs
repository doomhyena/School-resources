using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isGrounded = false;
    public bool isDoubled = false;
    private Rigidbody2D body;
    private Vector3 move;
    [SerializeField] private float hInput;
    private Animator anim;
    
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {
        Jump();
        anim.SetBool("run",hInput!=0);
        anim.SetBool("grounded", isGrounded);
        
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    hInput = 1;
        //}
        //else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    hInput = -1;
        //}
        //else hInput = 0;


        if (hInput > 0.001f) transform.localScale = Vector3.one;
        else if (hInput < -0.001f) transform.localScale = new Vector3(-1, 1, 1);
        move = new Vector3(hInput, 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            
            if (isDoubled)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(body.velocity.x, 2*5f), ForceMode2D.Impulse);
            else
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(body.velocity.x, 5f), ForceMode2D.Impulse);
        }
    }

    
}
