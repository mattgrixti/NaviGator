using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float maxspeed = 20f;          	//maximum character speed
    public bool facingRight = true;			// For determining which way the player is currently facing.

    private Rigidbody2D rb2D;               //access to rigidbody
    private Animator animator;              //access to animator

    public float jumpForce = 2f;         //force of jump
    public Transform groundCheck;           //gets the groundcheck gameobject that we will use
    public bool grounded = false;           //is on the ground
    public bool jump = false;              	//is jumping or not

    public bool onLadder;                   //player is in ladder zone
    public float climbSpeed;               //climb speed of player
    private float climbVelocity;            //
    private float gravityStore;             //keeps player from being pulled back to the ground by gravity while on ladder

    private LevelManeger levelManager;

    // Use this for initialization
    protected virtual void Start()
    {
        //gets the rigidbody2d of the character
        rb2D = GetComponent<Rigidbody2D>();
        //gets the animation control of the character
        animator = GetComponent<Animator>();

        //store current player gravity for when player leaves the ladder (to reset)
        gravityStore = rb2D.gravityScale;

        levelManager = levelManager = FindObjectOfType<LevelManeger>();
    }

    void Update()
    {
        //checks if character is on the ground or not to switch the grounded bool on and off. It checks if the variable is touching the ground
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floor"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        //when the player is in the zone, if player presses up the climb velocity will be changed, if no button, no change
        if (onLadder)
        {
            //animator.SetTrigger("Climb");
            rb2D.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            rb2D.velocity = new Vector2(rb2D.velocity.x, climbVelocity);
        }

        if (!onLadder)
        {
            rb2D.gravityScale = gravityStore;
        }
    }

    void FixedUpdate()
    {
        float horizontal = 0;
        float vertical = 0;

        //checks what key got pressed down and moves character accordingly
        //isStair is a control, checking if the character is touching the stairs to be able to go up or down.
        //if (Input.GetAxisRaw("Vertical") < 0)
        //{
        //    if (animator.GetBool("isStair") == true)
        //    {
        //        the force here is lesser because gravity will do most of the work
        //        vertical = -0.5f;
        //    }
        //}
        //if (Input.GetAxisRaw("Vertical") > 0)
        //{
        //    if (animator.GetBool("isStair") == true)
        //    {
        //        the force here is greater to surpass gravity
        //        vertical = 5.5f;
        //    }

        //}
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //if (animator.GetBool("isStair") == false)
            //{
                horizontal = -2.5f;
                if (facingRight)
                    Flip();
            //}
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //if (animator.GetBool("isStair") == false)
            //{
                horizontal = 2.5f;
                if (!facingRight)
                    Flip();
            //}
        }


        //checks if being pressed to run the animation
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);
        
        //jumping
        if (jump)
        {
            animator.SetTrigger("Jump");
            rb2D.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        //movement cycle is initiated, there is no need to check for collisions because we are using the Unity Physics Engine
        //so long as that it used, it checks for colissions by itself.
        Move(horizontal, vertical);
    }

    protected void Move(float xDir, float yDir)
    {
        //creates a vector out of the directions inputted by the player in Update() function
        Vector2 movementForce = new Vector2(xDir, yDir);
        //adds the force to the rigidbody so it moves, multiplying it so it gets past the linear drag and actually creates movement
        rb2D.AddForce(movementForce * 2.3f);

        //speed control, messing w values to know which speed is best
        //used to set a maximum velocity for the character, to avoid the force making them go too fast.
        if (rb2D.velocity.x > maxspeed)
            rb2D.velocity = new Vector2(maxspeed, rb2D.velocity.y);
        if (rb2D.velocity.y > maxspeed)
            rb2D.velocity = new Vector2(rb2D.velocity.x, maxspeed);

        return;
    }

    //makes character face opposite direction
    void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
        //applies the change, this will flip the character
		transform.localScale = theScale;
	}


    //OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is stairs.
        if (other.tag == "Stairs")
        {
            animator.SetBool("isStair", true);
        }
        //checks if the tag of the trigger collided with is the barrier
        //this barrier exists to tell the game that the player is now off the stairs and can no longer go up or down
        if (other.tag == "notStairs")
        {
            animator.SetBool("isStair", false);
        }

        if (other.tag == "Enemy")
        {
            if (grounded)
            {
                levelManager.RespawnPlayer();
                GameObject go = GameObject.Find("mainObject");
                UI ui = go.GetComponent<UI>();
                ui.HP -= 1;
            }
        }
    }
}
