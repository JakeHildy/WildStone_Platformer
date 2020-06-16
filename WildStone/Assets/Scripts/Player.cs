using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float climbSpeed = 3.0f;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidbody;
    Collider2D myCollider;
    Animator myAnimator;

    
    // Message then methods
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        myAnimator.SetBool("Running", IsRunning());
    }

    private void ClimbLadder()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) { return; }

        float controlThrow = Input.GetAxis("Vertical"); // -1 to +1
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        
        myAnimator.SetBool("Climbing", PlayerHasVerticalSpeed());
    }


    private void Jump()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
        
        if (Input.GetButtonDown("Jump"))
        {
             Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = IsRunning();
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private bool IsRunning()
    {
        return Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }

    private bool PlayerHasVerticalSpeed()
    {
        return Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
    }
}
