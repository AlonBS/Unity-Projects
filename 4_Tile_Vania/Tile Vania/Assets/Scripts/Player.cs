using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] float deathSpreadRange = 20;

    //State 
    bool isAlive = true;
    private float initGravity;
    

    // Cached refs
    private Rigidbody2D rigidBody;
    private Transform objectBody;
    private Animator animator;
    private CapsuleCollider2D bodyCollider;
    private BoxCollider2D feetCollider;




    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        objectBody = transform.Find("Body");
        animator = GetComponent<Animator>();
        animator.SetBool("IsAlive", isAlive);


        bodyCollider = objectBody.gameObject.GetComponent<CapsuleCollider2D>();
        feetCollider = objectBody.gameObject.GetComponent<BoxCollider2D>();

        initGravity = rigidBody.gravityScale;

    }
	
	// Update is called once per frame
	void Update () {

        if (isAlive)
        {
            Run();
            FlipSprite();
            Jump();
            ClimbLadder();
            Die();
        }
        
    }

    private void Run()
    {
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed; // Time.fixedDeltaTime
        rigidBody.velocity = new Vector2(deltaX, rigidBody.velocity.y);
    }


    private void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            //if (onAir)
            //{
            //    rigidBody.velocity += new Vector2(0, jumpSpeed / 2);
            //    onAir = false;
            //}

            // Only if not previously jumping - we can jump
            if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rigidBody.velocity += new Vector2(0, jumpSpeed);
                //onAir = true;
            }
        }
    }


    private void ClimbLadder()
    {

        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            animator.SetBool("Climbing", false);
            rigidBody.gravityScale = initGravity;
            return;
        }


        float deltaY = Input.GetAxis("Vertical") * climbSpeed;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, deltaY);

        rigidBody.gravityScale = 0f;

        bool hasVerticalSpeed = Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climbing", hasVerticalSpeed);
    }


    //private void Jump()
    //{
    //    // Only if not previously jumping - we can jump
    //    if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //    {
    //        grounded = true;
    //        onAir = false;
    //    }

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        if (grounded)
    //        {
    //            rigidBody.velocity = new Vector2(0, 0);
    //            rigidBody.AddForce(new Vector2(0, 1005));
    //            onAir = true;
    //        }

    //        else if (onAir)
    //        {
    //            onAir = false;
    //            rigidBody.velocity = new Vector2(0, 0);
    //            rigidBody.AddForce(new Vector2(0, 5));
    //        }
    //        ////numOfJumps++;
    //        ////Debug.Log(numOfJumps);
    //        //if (numOfJumps == 1)
    //        //{
    //        //    rigidBody.velocity += new Vector2(0, jumpSpeed);
                
    //        //}
    //        //else if (numOfJumps == 2)
    //        //{
    //        //    Debug.Log(rigidBody.velocity);
    //        //    rigidBody.velocity += new Vector2(0, jumpSpeed / Mathf.Abs(rigidBody.velocity.y));
    //        //}

            
    //    }
    //}


    private void FlipSprite()
    {
        bool hasSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", hasSpeed);
        if (hasSpeed)
        {
            objectBody.transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), objectBody.localScale.y);
        }
    }


    private void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            rigidBody.velocity = new Vector2(Random.Range(-deathSpreadRange, deathSpreadRange),
                                        Random.Range(-deathSpreadRange, +deathSpreadRange));

            isAlive = false;
            animator.SetTrigger("Dying");
        }


    }

}
