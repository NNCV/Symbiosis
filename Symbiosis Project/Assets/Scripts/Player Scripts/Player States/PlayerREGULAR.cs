using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerREGULAR : PlayerState {
    
    //Animation
    public Animator anim;

    //Physics
    public Rigidbody2D rb2d;
    public Vector3 movementSpeed;
    public Vector3 jumpSpeed;
    public Vector3 fallSpeed;
    public float yVelocityFallRequirement;
    public float xMaxSpeed;
    public float jumpMovementDampener;
    public bool jumped = false;
    public int direction;
    
    //to add more shit later

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        


        //MOVEMENT
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            if (jumped)
            {
                rb2d.AddRelativeForce(movementSpeed * Input.GetAxisRaw("Horizontal") * jumpMovementDampener);
            }
            else
            {
                rb2d.AddRelativeForce(movementSpeed * Input.GetAxisRaw("Horizontal"));
            }
        }



        //JUMP
        if(Input.GetAxisRaw("Vertical") > 0f && jumped == false)
        {
            rb2d.AddRelativeForce(jumpSpeed);
            jumped = true;
        }
        
        

        //MORE REALISTIC FALLING
        if(rb2d.velocity.y <= yVelocityFallRequirement)
        {
            rb2d.AddRelativeForce(fallSpeed);
        }



        //QUICK FIXING & LIMITING
        if(rb2d.velocity.x <= -xMaxSpeed)
        {
            rb2d.velocity = new Vector2(-xMaxSpeed, rb2d.velocity.y);
        }
        else if(rb2d.velocity.x >= xMaxSpeed)
        {
            rb2d.velocity = new Vector2(xMaxSpeed, rb2d.velocity.y);
        }
        
        if(rb2d.velocity.x < -0.05f)
        {
            transform.GetChild(0).transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(rb2d.velocity.x > 0.05f)
        {
            transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        }


        //ANIMATION STUFF
        if (rb2d.velocity.y >= 0 && jumped)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Jumped", true);
            anim.SetBool("Moving", false);
        }
        else if(rb2d.velocity.y <= 0 && jumped)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Moving", false);
        }
        else if(rb2d.velocity.y <= 0 && !jumped)
        {
            anim.SetBool("Falling", true);
            anim.SetBool("Moving", false);
            
        }
        else if(rb2d.velocity.x != 0)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Jumped", false);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Jumped", false);
            anim.SetBool("Moving", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GROUND")
        {
            jumped = false;
            anim.SetBool("Jumped", false);
        }
    }
}
