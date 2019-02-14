using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 10.0f;
    public float jumpForce = 500.0f;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;
    //private bool canJump = false;
    private Animator anim;
    private bool isFacingRight = true;

    // Reserved function. Runs only once when the object is created.
    // Used for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Listens to my space bar key being pressed
        {
            rBody.AddForce(new Vector2(0, jumpForce));
            //canJump = false;
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// Use FixedUpdate for Physics-based movement only
    /// </summary>
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        // Check direction of the player
        if(horiz < 0 && isFacingRight)
        {
            Flip();
        }
        else if(horiz > 0 && !isFacingRight)
        {
            Flip();
        }

        // Update Animator Information
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
