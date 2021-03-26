using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public float Speed;
    public ParticleSystem vfx;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            Flip();
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);

            Flip();
        }
       

        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(rb.velocity.x, Speed);
        }
        else if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -Speed);
        }
        
    }

    public void Flip()
    {
        // flipping the character sprite


        if (rb.velocity.x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (rb.velocity.x < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
