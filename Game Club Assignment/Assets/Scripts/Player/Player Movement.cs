using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpSpeed = 14f;
    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private BoxCollider2D coll;

    private enum MovementState { idle, running, jumping, falling }

    //[SerializeField] private AudioSource JumpSoundEffect;

    [SerializeField] private LayerMask JumpableGround;

    float dirx = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * MoveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        MovementState state;

        if (dirx > 0)
        {
            state = MovementState.running;
            transform.localScale = Vector3.one;
        }

        else if (dirx < 0)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }
   
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }

    public bool canAttack()
    {
        return dirx == 0;
    }
}
