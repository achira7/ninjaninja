using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    

    private Rigidbody2D playerRigidBody;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer flipSprite;
    private BoxCollider2D playerBoxCollider;

    private enum movementState { idle, running, jumping, falling };

    [SerializeField] private AudioSource audioJump;
    [SerializeField] private AudioSource walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        flipSprite = GetComponent<SpriteRenderer>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(dirX * runSpeed, playerRigidBody.velocity.y);

        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ) && isGrounded())
        {
            walkingSound.enabled = true;
        }
        else
        {
            walkingSound.enabled = false;
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            audioJump.Play();
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }

        updateAnimation();

    }

    private void updateAnimation()
    {
        movementState state;

        if (dirX > 0f)
        {
            state = movementState.running;
            flipSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = movementState.running;
            flipSprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (playerRigidBody.velocity.y > .1f)
        {
            state = movementState.jumping;
        }

        else if (playerRigidBody.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
