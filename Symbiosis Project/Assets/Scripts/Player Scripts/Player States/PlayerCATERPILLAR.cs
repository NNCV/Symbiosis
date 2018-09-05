using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCATERPILLAR : PlayerState {

    //ANIMATION
    public Animator anim;

    //PHYSICS
    public Rigidbody2D rb2d;
    public Vector3 movementSpeed;
    public float xMaxSpeed;
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if(Input.GetAxis("Horizontal") != 0f)
        {
            rb2d.AddRelativeForce(movementSpeed * Input.GetAxis("Horizontal"));
        }

        if(rb2d.velocity.x <= -xMaxSpeed)
        {
            rb2d.velocity = new Vector2(-xMaxSpeed, rb2d.velocity.y);
        }
        else if(rb2d.velocity.x >= xMaxSpeed)
        {
            rb2d.velocity = new Vector2(xMaxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -0.05f)
        {
            transform.GetChild(0).transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb2d.velocity.x > 0.05f)
        {
            transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        }
        
        if(Mathf.Abs(rb2d.velocity.x) >= 0.05f)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
